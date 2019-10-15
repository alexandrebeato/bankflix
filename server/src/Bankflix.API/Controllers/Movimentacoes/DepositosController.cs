using AutoMapper;
using Bankflix.API.Models.Movimentacoes.Depositos;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movimentacoes.Commands.Depositos;
using Movimentacoes.Domain.Depositos.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bankflix.API.Controllers.Movimentacoes
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class DepositosController : BaseController
    {
        private readonly IDepositoRepository _depositoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuario _usuario;
        private readonly IMediatorHandler _mediatorHandler;

        public DepositosController(INotificationHandler<DomainNotification> notifications, IUsuario usuario, IMediatorHandler mediator, IDepositoRepository depositoRepository, IMapper mapper) : base(notifications, usuario, mediator)
        {
            _depositoRepository = depositoRepository ?? throw new ArgumentNullException(nameof(mediator));
            _mediatorHandler = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        [HttpPost]
        [Route("solicitar")]
        [Authorize(Policy = "Cliente")]
        public async Task<IActionResult> SolicitarDeposito([FromBody] SolicitarDepositoViewModel solicitarDepositoViewModel)
        {
            if (!ModelState.IsValid)
                return Response(solicitarDepositoViewModel);

            solicitarDepositoViewModel.ClienteId = _usuario.ObterAutenticadoId();
            await _mediatorHandler.SendCommand(_mapper.Map<SolicitarDepositoCommand>(solicitarDepositoViewModel));
            return Response(solicitarDepositoViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "Agencia")]
        public IEnumerable<DepositoViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<DepositoViewModel>>(_depositoRepository.ObterTodos());
        }

        [HttpGet]
        [Route("meus")]
        [Authorize(Policy = "Cliente")]
        public IEnumerable<DepositoViewModel> ObterDepositosUsuarioAutenticado()
        {
            return _mapper.Map<IEnumerable<DepositoViewModel>>(_depositoRepository.ObterPorCliente(_usuario.ObterAutenticadoId()));
        }
    }
}
