using Clientes.CommandStack.Clientes.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Clientes.CommandStack.Clientes.Handlers
{
    public class ClienteEventHandler : INotificationHandler<ClienteCadastradoEvent>,
                                       INotificationHandler<ClienteAprovadoEvent>,
                                       INotificationHandler<ClienteRecusadoEvent>
    {
        public Task Handle(ClienteCadastradoEvent notification, CancellationToken cancellationToken)
        {
            // Talvez enviar e-mail de confirmação para o cliente e um para avisar a agência?
            return Task.CompletedTask;
        }

        public Task Handle(ClienteAprovadoEvent notification, CancellationToken cancellationToken)
        {
            // TODO: Criar conta do cliente
            return Task.CompletedTask;
        }

        public Task Handle(ClienteRecusadoEvent notification, CancellationToken cancellationToken)
        {
            // Talvez enviar e-mail para o cliente informando que ele foi recusado?
            return Task.CompletedTask;
        }
    }
}
