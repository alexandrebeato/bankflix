using Agencia.Domain.Agencia.Repository;
using Agencia.Domain.Agencia.Specifications;
using Core.Domain.Extensions;
using Core.Domain.Validations;
using FluentValidation;
using System;

namespace Agencia.Domain.Agencia.Validations
{
    public class AgenciaEstaConsistenciaParaCadastroValidation : DomainValidator<Agencia>
    {
        private readonly IAgenciaRepository _agenciaRepository;

        public AgenciaEstaConsistenciaParaCadastroValidation(Agencia entidade, IAgenciaRepository agenciaRepository) : base(entidade)
        {
            _agenciaRepository = agenciaRepository ?? throw new ArgumentNullException(nameof(agenciaRepository));

            Validar();
        }

        private void Validar()
        {
            RuleFor(a => a)
                .IsValid(new DeveExistirApenasUmaAgenciaSpecification(_entidade, _agenciaRepository))
                .WithMessage("Já possui uma agência cadastrada na base.");
        }
    }
}
