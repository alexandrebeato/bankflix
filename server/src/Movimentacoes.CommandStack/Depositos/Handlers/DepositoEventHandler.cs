using System.Threading;
using System.Threading.Tasks;
using Core.Domain.Interfaces;
using MediatR;
using Movimentacoes.Commands.Depositos;
using Movimentacoes.CommandStack.Depositos.Events;

namespace Movimentacoes.CommandStack.Depositos.Handlers
{
    public class DepositoEventHandler : INotificationHandler<DepositoSolicitadoEvent>
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DepositoEventHandler(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        public Task Handle(DepositoSolicitadoEvent notification, CancellationToken cancellationToken)
        {
            return _mediatorHandler.SendCommand(new EfetuarDepositoCommand(notification.Id), enqueue: true);
        }
    }
}
