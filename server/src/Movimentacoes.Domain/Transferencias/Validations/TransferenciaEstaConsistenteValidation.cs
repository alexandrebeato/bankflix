using Core.Domain.Validations;
using FluentValidation;
using Movimentacoes.Domain.Transferencias.Enums;

namespace Movimentacoes.Domain.Transferencias.Validations
{
    public class TransferenciaEstaConsistenteValidation : DomainValidator<Transferencia>
    {
        public TransferenciaEstaConsistenteValidation(Transferencia entidade) : base(entidade)
        {
            ValidarId();
            ValidarContaOrigem();
            ValidarContaDestino();
            ValidarValor();
            ValidarSituacao();
            ValidarMotivoRecusa();
            ValidarDataHoraCriacao();
        }

        private void ValidarId() =>
            RuleFor(t => t.Id)
                .NotEmpty().WithMessage("O ID é obrigatório.");

        private void ValidarContaOrigem()
        {
            RuleFor(t => t.ContaOrigem)
                .NotNull().WithMessage("É obrigatório informar a conta de origem da transferência.");

            When(t => t.ContaOrigem != null, () =>
            {
                RuleFor(t => t.ContaOrigem.Id)
                    .NotEmpty().WithMessage("É obrigatório informar o ID da conta de origem.");

                RuleFor(t => t.ContaOrigem.Numero)
                    .NotEmpty().WithMessage("É obrigatório informar o número da conta de origem.");

                RuleFor(t => t.ContaOrigem.DigitoVerificador)
                    .NotEmpty().WithMessage("É obrigatório informar o dígito verificador da conta de origem.");

                RuleFor(t => t.ContaOrigem.Cliente)
                    .NotNull().WithMessage("É obrigatório informar o cliente da conta de origem.");

                When(t => t.ContaOrigem.Cliente != null, () =>
                {
                    RuleFor(t => t.ContaOrigem.Cliente.Id)
                        .NotEmpty().WithMessage("É obrigatório informar o ID do cliente da conta de origem.");

                    RuleFor(t => t.ContaOrigem.Cliente.NomeCompleto)
                        .NotEmpty().WithMessage("É obrigatório informar o nome completo do cliente da conta de origem.");

                    RuleFor(t => t.ContaOrigem.Cliente.Cpf)
                        .NotEmpty().WithMessage("É obrigatório informar o CPF do cliente da conta de origem.");
                });
            });
        }

        private void ValidarContaDestino()
        {
            RuleFor(t => t.ContaDestino)
                .NotNull().WithMessage("É obrigatório informar a conta de destino da transferência.");

            When(t => t.ContaDestino != null, () =>
            {
                RuleFor(t => t.ContaDestino.Id)
                    .NotEmpty().WithMessage("É obrigatório informar o ID da conta de destino.");

                RuleFor(t => t.ContaDestino.Numero)
                    .NotEmpty().WithMessage("É obrigatório informar o número da conta de destino.");

                RuleFor(t => t.ContaDestino.DigitoVerificador)
                    .NotEmpty().WithMessage("É obrigatório informar o dígito verificador da conta de destino.");

                RuleFor(t => t.ContaDestino.Cliente)
                    .NotNull().WithMessage("É obrigatório informar o cliente da conta de destino.");

                When(t => t.ContaDestino.Cliente != null, () =>
                {
                    RuleFor(t => t.ContaDestino.Cliente.Id)
                        .NotEmpty().WithMessage("É obrigatório informar o ID do cliente da conta de destino.");

                    RuleFor(t => t.ContaDestino.Cliente.NomeCompleto)
                        .NotEmpty().WithMessage("É obrigatório informar o nome completo do cliente da conta de destino.");

                    RuleFor(t => t.ContaDestino.Cliente.Cpf)
                        .NotEmpty().WithMessage("É obrigatório informar o CPF do cliente da conta de destino.");
                });
            });
        }

        private void ValidarValor() =>
            RuleFor(d => d.Valor)
                .GreaterThan(0).WithMessage("O valor não pode ser negativo e nem igual a 0 (zero).");

        private void ValidarSituacao()
        {
            RuleFor(d => d.Situacao)
                .NotNull().WithMessage("É obrigatório possuir uma situação.");

            When(d => !string.IsNullOrEmpty(d.MotivoRecusa), () =>
            {
                RuleFor(d => d.Situacao)
                    .Equal(SituacaoTransferencia.Recusada).WithMessage("Para possuir um motivo de recusa a transferência deve ser recusada.");
            });
        }

        private void ValidarMotivoRecusa() =>
            When(d => d.Situacao == SituacaoTransferencia.Recusada, () =>
            {
                RuleFor(d => d.MotivoRecusa)
                    .NotEmpty().WithMessage("Para ser recusada, a transferência precisa de um motivo.");
            });

        private void ValidarDataHoraCriacao() =>
            RuleFor(d => d.DataHoraCriacao)
                .NotEmpty().WithMessage("A data e hora de criação são obrigatórias.");
    }
}
