using Clientes.Domain.Clientes.Repository;
using Clientes.Domain.Clientes.Specifications;
using Core.Domain.Extensions;
using Core.Domain.Validations;
using FluentValidation;
using System;

namespace Clientes.Domain.Clientes.Validations
{
    public class ClienteEstaConsistenteParaCadastroValidation : DomainValidator<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteEstaConsistenteParaCadastroValidation(Cliente entidade, IClienteRepository clienteRepository) : base(entidade)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));

            Validar();
        }

        private void Validar()
        {
            RuleFor(c => c)
                .IsValid(new ClienteDevePossuirCpfUnicoSpecification(_entidade, _clienteRepository))
                .WithMessage("CPF já em utilização.");

            RuleFor(c => c)
                .IsValid(new ClienteDevePossuirEmailUnicoSpecification(_entidade, _clienteRepository))
                .WithMessage("E-mail já em utilização.");
        }
    }
}
