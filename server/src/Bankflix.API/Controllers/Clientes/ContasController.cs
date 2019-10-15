using AutoMapper;
using Bankflix.API.Models.Clientes.Contas;
using Clientes.Domain.Contas.Repository;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Bankflix.API.Controllers.Clientes
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContasController : BaseController
    {
        private readonly IContaRepository _contaRepository;
        private readonly IMediatorHandler _mediatorHandler;
        private readonly IMapper _mapper;
        private readonly IUsuario _usuario;

        public ContasController(INotificationHandler<DomainNotification> notifications, IUsuario usuario, IMediatorHandler mediator, IContaRepository contaRepository, IMapper mapper) : base(notifications, usuario, mediator)
        {
            _contaRepository = contaRepository ?? throw new ArgumentNullException(nameof(contaRepository));
            _mediatorHandler = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        [HttpGet]
        [Authorize(Policy = "Agencia")]
        public IEnumerable<ContaViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ContaViewModel>>(_contaRepository.ObterTodos());
        }

        [HttpGet]
        [Route("minha")]
        [Authorize(Policy = "Cliente")]
        public ContaViewModel ObterContaUsuarioLogado()
        {
            return _mapper.Map<ContaViewModel>(_contaRepository.ObterPorId(_usuario.ObterAutenticadoId()));
        }
    }
}
