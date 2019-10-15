using AutoMapper;
using Bankflix.API.Models.Clientes.Clientes;
using Clientes.Commands.Clientes;
using Clientes.Domain.Clientes.Enums;
using Clientes.Domain.Clientes.Repository;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bankflix.API.Controllers.Clientes
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : BaseController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediatorHandler;

        public ClientesController(INotificationHandler<DomainNotification> notifications, IUsuario usuario, IMediatorHandler mediator, IClienteRepository clienteRepository, IMapper mapper) : base(notifications, usuario, mediator)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _mediatorHandler = mediator ?? throw new ArgumentNullException(nameof(mediator)); ;
        }

        [HttpPost]
        [Route("cadastrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Cadastrar([FromBody] CadastrarClienteViewModel cadastrarClienteViewModel)
        {
            if (!ModelState.IsValid)
                return Response(cadastrarClienteViewModel);

            await _mediatorHandler.SendCommand(_mapper.Map<CadastrarClienteCommand>(cadastrarClienteViewModel));
            return Response(cadastrarClienteViewModel);
        }

        [HttpGet]
        [Authorize(Policy = "Agencia")]
        public IEnumerable<ClienteViewModel> ObterTodos()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterTodos());
        }

        [HttpGet]
        [Route("pendentes")]
        [Authorize(Policy = "Agencia")]
        public IEnumerable<ClienteViewModel> ObterPendentes()
        {
            return _mapper.Map<IEnumerable<ClienteViewModel>>(_clienteRepository.ObterPorSituacao(SituacaoCliente.Pendente));
        }

        [HttpPost]
        [Route("{id:guid}/aprovar")]
        [Authorize(Policy = "Agencia")]
        public async Task<IActionResult> Aprovar([FromRoute] Guid id)
        {
            await _mediatorHandler.SendCommand(_mapper.Map<AprovarClienteCommand>(id));
            return Response();
        }

        [HttpPost]
        [Route("{id:guid}/recusar")]
        [Authorize(Policy = "Agencia")]
        public async Task<IActionResult> Recusar([FromRoute] Guid id)
        {
            await _mediatorHandler.SendCommand(_mapper.Map<RecusarClienteCommand>(id));
            return Response();
        }
    }
}
