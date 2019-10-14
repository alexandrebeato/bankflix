using Core.Domain.Validations;
using Movimentacoes.Domain.Contas.Repository;

namespace Movimentacoes.Domain.Transferencias.Specifications
{
    public class ContaOrigemDevePossuirSaldoDisponivelSpecification : DomainSpecification<Transferencia>
    {
        private readonly IContaRepository _contaRepository;

        public ContaOrigemDevePossuirSaldoDisponivelSpecification(Transferencia entidade, IContaRepository contaRepository) : base(entidade)
        {
            _contaRepository = contaRepository;
        }

        public override bool IsValid()
        {
            var conta = _contaRepository.ObterPorId(_entidade.ContaOrigem.Id);

            if (conta == null)
                return false;

            return conta.SaldoDisponivel >= _entidade.Valor;
        }
    }
}
