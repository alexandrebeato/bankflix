using Clientes.Domain.Contas.Repository;
using Core.Domain.Validations;
using System;

namespace Clientes.Domain.Contas.Specifications
{
    public class ClienteDevePossuirApenasUmaContaSpecification : DomainSpecification<Conta>
    {
        private readonly IContaRepository _contaRepository;

        public ClienteDevePossuirApenasUmaContaSpecification(Conta entidade, IContaRepository contaRepository) : base(entidade)
        {
            _contaRepository = contaRepository ?? throw new ArgumentNullException(nameof(contaRepository));
        }

        public override bool IsValid()
        {
            var conta = _contaRepository.ObterPorCliente(_entidade.ClienteId);
            return conta == null;
        }
    }
}
