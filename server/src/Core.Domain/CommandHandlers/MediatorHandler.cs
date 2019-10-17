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
            _connectionFactory = new ConnectionFactory() { Uri = new Uri(configuration["rabbitmq:uri"]) };
            _host = host ?? throw new ArgumentNullException(nameof(host));
        }

        public Task SendCommand<T>(T comando, CancellationToken cancellation = default, bool enqueue = false) where T : Command
        {
            if (enqueue)
                return PublicarFila(comando, cancellation);
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
    }
}
