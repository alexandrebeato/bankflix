using Clientes.Domain.Clientes.Repository;
using Core.Domain.Validations;
using System;

namespace Clientes.Domain.Clientes.Specifications
{
    public class ClienteDevePossuirCpfUnicoSpecification : DomainSpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirCpfUnicoSpecification(Cliente entidade, IClienteRepository clienteRepository) : base(entidade)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public override bool IsValid()
        {
            var cliente = _clienteRepository.ObterPorCpf(_entidade.Cpf);

            if (cliente == null)
                return true;

            return cliente.Id == _entidade.Id;
        }
    }
}
