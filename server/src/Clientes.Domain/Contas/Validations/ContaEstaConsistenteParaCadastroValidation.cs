using Clientes.Domain.Contas.Repository;
using Clientes.Domain.Contas.Specifications;
using Core.Domain.Extensions;
using Core.Domain.Validations;
using FluentValidation;
using System;

namespace Clientes.Domain.Contas.Validations
{
    public class ContaEstaConsistenteParaCadastroValidation : DomainValidator<Conta>
    {
        private readonly IContaRepository _contaRepository;

        public ContaEstaConsistenteParaCadastroValidation(Conta entidade, IContaRepository contaRepository) : base(entidade)
        {
            _contaRepository = contaRepository ?? throw new ArgumentNullException(nameof(contaRepository));

            Validar();
        }

        private void Validar()
        {
            RuleFor(c => c)
                .IsValid(new ClienteDevePossuirApenasUmaContaSpecification(_entidade, _contaRepository))
                .WithMessage("Cliente já possui uma conta");

            RuleFor(c => c)
                .IsValid(new ContaDevePossuirNumeroUnicoSpecification(_entidade, _contaRepository))
                .WithMessage("Número de conta já em utilização");
        }
    }
}
