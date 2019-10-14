using Core.Domain.Interfaces;
using MediatR;
using Movimentacoes.Commands.Transferencias;
using Movimentacoes.CommandStack.Transferencias.Events;
using System.Threading;
using System.Threading.Tasks;

namespace Movimentacoes.CommandStack.Transferencias.Handlers
{
    public class TransferenciaEventHandler : INotificationHandler<TransferenciaSolicitadaEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public TransferenciaEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public Task Handle(TransferenciaSolicitadaEvent notification, CancellationToken cancellationToken)
        {
            return _mediatorHandler.SendCommand(new EfetuarTransferenciaCommand(notification.Id), enqueue: true);
        }
    }
}
