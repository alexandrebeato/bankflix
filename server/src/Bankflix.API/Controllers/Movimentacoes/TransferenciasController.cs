using AutoMapper;
using Bankflix.API.Models.Movimentacoes.Transferencias;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movimentacoes.Commands.Transferencias;
using Movimentacoes.Domain.Transferencias.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bankflix.API.Controllers.Movimentacoes
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TransferenciasController : BaseController
    {
        private readonly ITransferenciaRepository _transferenciaRepository;
        private readonly IMapper _mapper;
        private readonly IUsuario _usuario;
        private readonly IMediatorHandler _mediatorHandler;

        public TransferenciasController(INotificationHandler<DomainNotification> notifications, IUsuario usuario, IMediatorHandler mediator, ITransferenciaRepository transferenciaRepository, IMapper mapper) : base(notifications, usuario, mediator)
        {
            _transferenciaRepository = transferenciaRepository ?? throw new ArgumentNullException(nameof(mediator));
            _mediatorHandler = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        [HttpPost]
        [Route("solicitar")]
        [Authorize(Policy = "Cliente")]
        public async Task<IActionResult> SolicitarTransferencia([FromBody] SolicitarTransferenciaViewModel solicitarTransferenciaViewModel)
        {
            if (!ModelState.IsValid)
                return Response(solicitarTransferenciaViewModel);

            solicitarTransferenciaViewModel.ClienteOrigemId = _usuario.ObterAutenticadoId();
            await _mediatorHandler.SendCommand(_mapper.Map<SolicitarTransferenciaCommand>(solicitarTransferenciaViewModel));
            return Response(solicitarTransferenciaViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "Agencia")]
        public IEnumerable<TransferenciaViewModel> ObterTodas()
        {
            return _mapper.Map<IEnumerable<TransferenciaViewModel>>(_transferenciaRepository.ObterTodos());
        }

        [HttpGet]
        [Route("minhas-realizadas")]
        [Authorize(Policy = "Cliente")]
        public IEnumerable<TransferenciaViewModel> ObterTransferenciasRealizadasUsuarioAutenticado()
        {
            return _mapper.Map<IEnumerable<TransferenciaViewModel>>(_transferenciaRepository.ObterPorClienteOrigem(_usuario.ObterAutenticadoId()));
        }

        [HttpGet]
        [Route("minhas-recebidas")]
        [Authorize(Policy = "Cliente")]
        public IEnumerable<TransferenciaViewModel> ObterTransferenciasRecebidasUsuarioAutenticado()
        {
            return _mapper.Map<IEnumerable<TransferenciaViewModel>>(_transferenciaRepository.ObterPorClienteDestino(_usuario.ObterAutenticadoId()));
        }
    }
}
