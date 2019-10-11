using Agencia.Domain.Agencia.Repository;
using AutoMapper;
using Bankflix.API.Models.Agencia;
using Core.Domain.Interfaces;
using Core.Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        public IEnumerable<AgenciaViewModel> ObterAgencias()
        {
            return _mapper.Map<IEnumerable<AgenciaViewModel>>(_agenciaRepository.ObterTodos());
        }
    }
}
