using Agencia.Domain.Agencia.Repository;
using AutoMapper;
using Bankflix.API.Models.Agencia;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Bankflix.API.Controllers.Agencia
{
    [ApiController]
    [Route("[controller]")]
    public class AgenciaController : ControllerBase
    {
        private readonly IAgenciaRepository _agenciaRepository;
        private readonly IMapper _mapper;

        public AgenciaController(IAgenciaRepository agenciaRepository, IMapper mapper)
        {
            _agenciaRepository = agenciaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<AgenciaViewModel> ObterAgencias()
        {
            return _mapper.Map<IEnumerable<AgenciaViewModel>>(_agenciaRepository.ObterTodos());
        }
    }
}
