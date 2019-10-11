using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Bankflix.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;
        protected Guid UsuarioId { get; set; }

        protected BaseController(INotificationHandler<DomainNotification> notifications, IUsuario usuario, IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;

            if (usuario.VerificarSeEstaAutenticado())
                UsuarioId = usuario.ObterAutenticadoId();
        }

        protected new IActionResult Response(object result = null)
        {
            if (!ModelState.IsValid)
                NotificarErroModelInvalida();

            if (OperacaoValida())
            {
                return Ok(result);
            }

            return BadRequest(new
            {
                errors = _notifications.GetNotifications().Select(p => p.Value)
            });
        }

        protected bool OperacaoValida()
        {
            return (!_notifications.HasNotifications());
        }

        protected void NotificarErroModelInvalida()
        {
            var erros = ModelState.Values.SelectMany(p => p.Errors);
            foreach (var erro in erros)
            {
                var erroMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
                NotificarErro(string.Empty, erroMsg);
            }
        }

        protected void NotificarErro(string codigo, string mensagem)
        {
            _mediator.RaiseEvent(new DomainNotification(codigo, mensagem));
        }
    }
}
