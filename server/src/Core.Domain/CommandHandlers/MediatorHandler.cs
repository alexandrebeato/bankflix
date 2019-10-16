using Core.Domain.Commands;
using Core.Domain.Events;
using Core.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.CommandHandlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;
        private readonly IConnectionFactory _connectionFactory;
        private readonly IQueueableService _queueableService;
        private readonly IHost _host;

        public MediatorHandler(IMediator mediator, IQueueableService queueableService, IConfiguration configuration, IHost host)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _queueableService = queueableService ?? throw new ArgumentNullException(nameof(queueableService));
            _connectionFactory = new ConnectionFactory() { HostName = configuration["rabbitmq:hostname"] };
            _host = host ?? throw new ArgumentNullException(nameof(host));
        }

        public Task SendCommand<T>(T comando, CancellationToken cancellation = default, bool enqueue = false) where T : Command
        {
            if (enqueue)
                return PublicarFila(comando, cancellation); // TODO: Adicionar à fila com circuit break via polly.

            else
                return _mediator.Send(comando, cancellation);
        }

        public Task RaiseEvent<T>(T evento, CancellationToken cancellation = default, bool enqueue = false) where T : Event => _mediator.Publish(evento, cancellation);

        public Task PublicarFila<T>(T comando, CancellationToken cancellation = default)
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: typeof(T).FullName,
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var bodyMessage = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(comando));

                    channel.BasicPublish(exchange: "",
                                         routingKey: typeof(T).FullName,
                                         basicProperties: null,
                                         body: bodyMessage);

                    Console.WriteLine($"Mensagem do tipo {typeof(T).FullName} enviada.");
                }
            }

            return Task.CompletedTask;
        }

        public Task SubscreverFilas()
        {
            using (var connection = _connectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    foreach (var queueType in _queueableService.Comandos)
                    {
                        channel.QueueDeclare(queue: queueType.FullName,
                                             durable: true,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);
                    }

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += async (model, eventArgs) =>
                    {
                        var bodyMessage = eventArgs.Body;
                        var comando = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(bodyMessage), _queueableService.Comandos.Find(t => t.FullName == eventArgs.RoutingKey));
                        Console.WriteLine($"Mensagem do tipo {comando.GetType().FullName} recebida.");

                        using (var scope = _host.Services.CreateScope())
                        {
                            var services = scope.ServiceProvider;
                            var mediator = services.GetRequiredService<IMediator>();
                            Thread.Sleep(30000);

                            try
                            {
                                await mediator.Send((Command)comando);
                                channel.BasicAck(eventArgs.DeliveryTag, false);
                            }

                            catch
                            {
                                channel.BasicNack(eventArgs.DeliveryTag, false, true);
                            }
                        }
                    };

                    foreach (var queueType in _queueableService.Comandos)
                    {
                        channel.BasicConsume(queueType.FullName,
                                         autoAck: false,
                                         consumer: consumer);
                    }

                    Console.ReadLine();
                    return Task.CompletedTask;
                }
            }
        }
    }
}
