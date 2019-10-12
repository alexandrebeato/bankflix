using Clientes.Domain.Clientes.Repository;
using Core.Domain.Validations;
using System;

namespace Clientes.Domain.Clientes.Specifications
{
    public class ClienteDevePossuirEmailUnicoSpecification : DomainSpecification<Cliente>
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteDevePossuirEmailUnicoSpecification(Cliente entidade, IClienteRepository clienteRepository) : base(entidade)
        {
            _clienteRepository = clienteRepository ?? throw new ArgumentNullException(nameof(clienteRepository));
        }

        public override bool IsValid()
        {
            var cliente = _clienteRepository.ObterPorEmail(_entidade.Email);

            if (cliente == null)
                return true;

            return cliente.Id == _entidade.Id;
        }
    }
}
