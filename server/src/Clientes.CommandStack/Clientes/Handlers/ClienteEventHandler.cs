using Clientes.Commands.Contas;
using Clientes.CommandStack.Clientes.Events;
using Core.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clientes.CommandStack.Clientes.Handlers
{
    public class ClienteEventHandler : INotificationHandler<ClienteCadastradoEvent>,
                                       INotificationHandler<ClienteAprovadoEvent>,
                                       INotificationHandler<ClienteRecusadoEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClienteEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler ?? throw new ArgumentNullException(nameof(mediatorHandler));
        }

        public Task Handle(ClienteCadastradoEvent notification, CancellationToken cancellationToken)
        {
            // Talvez enviar e-mail de confirmação para o cliente e um para avisar a agência?
            return Task.CompletedTask;
        }

        public Task Handle(ClienteAprovadoEvent notification, CancellationToken cancellationToken)
        {
            _mediatorHandler.SendCommand(new CriarContaCommand(Guid.NewGuid(), notification.Id, DateTime.UtcNow));
            return Task.CompletedTask;
        }

        public Task Handle(ClienteRecusadoEvent notification, CancellationToken cancellationToken)
        {
            // Talvez enviar e-mail para o cliente informando que ele foi recusado?
            return Task.CompletedTask;
        }
    }
}
