using Agencia.Domain.Agencia.Repository;
using AutoMapper;
using Bankflix.API.Models.Agencia;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Bankflix.API.Controllers.Agencia
{
    [ApiController]
    [Route("[controller]")]
    public class AgenciaController : BaseController
    {
        private readonly IAgenciaRepository _agenciaRepository;
        private readonly IMapper _mapper;

        public AgenciaController(INotificationHandler<DomainNotification> notifications, IUsuario usuario, IMediatorHandler mediator, IAgenciaRepository agenciaRepository, IMapper mapper) : base(notifications, usuario, mediator)
        {
            _agenciaRepository = agenciaRepository ?? throw new ArgumentNullException(nameof(agenciaRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public AgenciaViewModel ObterAgencia()
        {
            var agencia = _agenciaRepository.ObterTodos()?.FirstOrDefault();
            return _mapper.Map<AgenciaViewModel>(agencia ?? throw new ArgumentNullException(nameof(agencia)));
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("login")]
        public IActionResult Login([FromBody] LoginViewModel loginViewModel)
        {
            var agencia = _agenciaRepository.Buscar(a => a.Cnpj == loginViewModel.Cnpj && a.Senha == loginViewModel.SenhaCriptografada).FirstOrDefault();

            if (agencia == null)
            {
                NotificarErro("Agencia", "CNPJ/Senha inválidos");
                return Response(loginViewModel);
            }

            return Response(_mapper.Map<AgenciaViewModel>(agencia));
        }
    }
}
