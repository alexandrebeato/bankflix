using Core.Domain.Commands;
using Core.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Polly;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.Services
{
    public class QueueHostedService : IHostedService
    {
        private readonly IQueueableService _queueableService;
        private readonly IHost _host;
        private readonly IConfiguration _configuration;
        private IModel _channel = null;
        private IConnection _connection = null;

        public QueueHostedService(IQueueableService queueableService, IConfiguration configuration, IHost host)
        {
            _queueableService = queueableService ?? throw new ArgumentNullException(nameof(queueableService));
            _host = host ?? throw new ArgumentNullException(nameof(host));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            var policy = Policy.Handle<BrokerUnreachableException>().WaitAndRetryForever(retryAttempt => TimeSpan.FromSeconds(5), onRetry: (exception, timespan) =>
                Console.WriteLine("Falha ao conectar com RabbitMQ: " + exception.Message));

            policy.Execute(() => Executar());
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _channel.Dispose();
            _connection.Dispose();
            return Task.CompletedTask;
        }

        private void Executar()
        {
            var connectionFactory = new ConnectionFactory() { Uri = new Uri(_configuration["rabbitmq:uri"]) };
            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();

            foreach (var queueType in _queueableService.Comandos)
            {
                _channel.QueueDeclare(queue: queueType.FullName,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
            }

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += async (model, eventArgs) =>
            {
                Console.WriteLine("Mensagem recebida");
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
                        _channel.BasicAck(eventArgs.DeliveryTag, false);
                    }

                    catch
                    {
                        _channel.BasicNack(eventArgs.DeliveryTag, false, true);
                    }
                }
            };

            foreach (var queueType in _queueableService.Comandos)
            {
                _channel.BasicConsume(queueType.FullName,
                                 autoAck: false,
                                 consumer: consumer);
            }
        }
    }
}
