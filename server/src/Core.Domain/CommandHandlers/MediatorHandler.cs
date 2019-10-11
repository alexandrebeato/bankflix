using Core.Domain.Commands;
using Core.Domain.Events;
using Core.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Domain.CommandHandlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T comando, CancellationToken cancellation = default) where T : Command => _mediator.Send(comando, cancellation);

        public Task RaiseEvent<T>(T evento, CancellationToken cancellation = default) where T : Event => _mediator.Publish(evento, cancellation);
    }
}
