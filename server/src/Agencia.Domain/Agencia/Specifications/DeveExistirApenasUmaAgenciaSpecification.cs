using Agencia.Domain.Agencia.Repository;
using Core.Domain.Validations;
using System;
using System.Linq;

namespace Agencia.Domain.Agencia.Specifications
{
    public class DeveExistirApenasUmaAgenciaSpecification : DomainSpecification<Agencia>
    {
        private readonly IAgenciaRepository _agenciaRepository;

        public DeveExistirApenasUmaAgenciaSpecification(Agencia entidade, IAgenciaRepository agenciaRepository) : base(entidade)
        {
            _agenciaRepository = agenciaRepository ?? throw new ArgumentNullException(nameof(agenciaRepository));
        }

        public override bool IsValid()
        {
            return !_agenciaRepository.ObterTodos().Any();
        }
    }
}
