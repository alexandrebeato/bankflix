using AutoMapper;
using Bankflix.API.Models.Movimentacoes.Movimentacoes;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movimentacoes.Domain.Movimentacoes.Repository;
using System;
using System.Collections.Generic;

namespace Bankflix.API.Controllers.Movimentacoes
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class MovimentacoesController : BaseController
    {
        private readonly IMovimentacaoRepository _movimentacaoRepository;
        private readonly IMapper _mapper;
        private readonly IUsuario _usuario;

        public MovimentacoesController(INotificationHandler<DomainNotification> notifications, IUsuario usuario, IMediatorHandler mediator, IMovimentacaoRepository movimentacaoRepository, IMapper mapper) : base(notifications, usuario, mediator)
        {
            _movimentacaoRepository = movimentacaoRepository ?? throw new ArgumentNullException(nameof(movimentacaoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _usuario = usuario ?? throw new ArgumentNullException(nameof(usuario));
        }

        [HttpGet]
        [Authorize(Policy = "Agencia")]
        public IEnumerable<MovimentacaoViewModel> ObterTodas()
        {
            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepository.ObterTodos());
        }

        [HttpGet]
        [Route("minhas")]
        [Authorize(Policy = "Cliente")]
        public IEnumerable<MovimentacaoViewModel> ObterMovimentacoesUsuarioAutenticado()
        {
            return _mapper.Map<IEnumerable<MovimentacaoViewModel>>(_movimentacaoRepository.ObterPorCliente(_usuario.ObterAutenticadoId()));
        }
    }
}
