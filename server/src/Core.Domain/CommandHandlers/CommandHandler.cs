using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using FluentValidation.Results;
using MediatR;
using System.Threading.Tasks;

namespace Core.Domain.CommandHandlers
{
    public abstract class CommandHandler
    {
        protected readonly IMediatorHandler _mediator;
        protected readonly DomainNotificationHandler _notifications;

        protected CommandHandler(IMediatorHandler mediator, INotificationHandler<DomainNotification> notifications)
        {
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }

        protected void NotificarValidacoesErro(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _mediator.RaiseEvent(new DomainNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected void NotificarErro(string nome, string mensagem) => _mediator.RaiseEvent(new DomainNotification(nome, mensagem));

        protected bool HasNotifications() => _notifications.HasNotifications();

        protected Task<bool> Sucesso() => Task.FromResult(true);

        protected Task<bool> Falha() => Task.FromResult(false);
    }
}
