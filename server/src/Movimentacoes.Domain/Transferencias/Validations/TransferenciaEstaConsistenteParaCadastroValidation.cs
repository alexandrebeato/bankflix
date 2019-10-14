using Core.Domain.Extensions;
using Core.Domain.Validations;
using FluentValidation;
using Movimentacoes.Domain.Contas.Repository;
using Movimentacoes.Domain.Transferencias.Specifications;

namespace Movimentacoes.Domain.Transferencias.Validations
{
    public class TransferenciaEstaConsistenteParaCadastroValidation : DomainValidator<Transferencia>
    {
        private readonly IContaRepository _contaRepository;

        public TransferenciaEstaConsistenteParaCadastroValidation(Transferencia entidade, IContaRepository contaRepository) : base(entidade)
        {
            _contaRepository = contaRepository;

            Validar();
        }

        private void Validar() =>
            RuleFor(t => t)
                .IsValid(new ContaOrigemDevePossuirSaldoDisponivelSpecification(_entidade, _contaRepository))
                .WithMessage("Saldo indisponível.");
    }
}
