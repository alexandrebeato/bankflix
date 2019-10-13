using Core.Domain.Validations;
using FluentValidation;
using Movimentacoes.Domain.Depositos.Enums;

namespace Movimentacoes.Domain.Depositos.Validations
{
    public class DepositoEstaConsistenteValidation : DomainValidator<Deposito>
    {
        public DepositoEstaConsistenteValidation(Deposito entidade) : base(entidade)
        {
            ValidarId();
            ValidarConta();
            ValidarValor();
            ValidarSituacao();
            ValidarMotivoCancelamento();
            ValidarDataHoraCriacao();
        }

        private void ValidarId() =>
            RuleFor(d => d.Id)
                .NotEmpty().WithMessage("O ID é obrigatório.");

        private void ValidarConta()
        {
            RuleFor(d => d.Conta)
                .NotNull().WithMessage("É obrigatório informar a conta para o depósito.");

            When(d => d.Conta != null, () =>
            {
                RuleFor(d => d.Conta.Id)
                    .NotEmpty().WithMessage("É obrigatório informar o ID da conta");

                RuleFor(d => d.Conta.Numero)
                    .NotEmpty().WithMessage("É obrigatório informar o número da conta.");

                RuleFor(d => d.Conta.DigitoVerificador)
                    .NotEmpty().WithMessage("É obrigatório informar o dígito verificador da conta.");

                RuleFor(d => d.Conta.Cliente)
                    .NotNull().WithMessage("É obrigatório informar o cliente da conta.");

                When(d => d.Conta.Cliente != null, () =>
                {
                    RuleFor(d => d.Conta.Cliente.Id)
                        .NotEmpty().WithMessage("É obrigatório informar o ID do cliente.");

                    RuleFor(d => d.Conta.Cliente.NomeCompleto)
                        .NotEmpty().WithMessage("É obrigatório informar o nome completo do cliente.");

                    RuleFor(d => d.Conta.Cliente.Cpf)
                        .NotEmpty().WithMessage("É obrigatório informar o CPF do cliente.");
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

            When(d => !string.IsNullOrEmpty(d.MotivoCancelamento), () =>
            {
                RuleFor(d => d.Situacao)
                    .Equal(SituacaoDeposito.Cancelado).WithMessage("Para possuir um motivo de cancelamento o depósito deve ser cancelado.");
            });
        }

        private void ValidarMotivoCancelamento() =>
            When(d => d.Situacao == SituacaoDeposito.Cancelado, () =>
            {
                RuleFor(d => d.MotivoCancelamento)
                    .NotEmpty().WithMessage("Para ser cancelado, o depósito precisa de um motivo.");
            });

        private void ValidarDataHoraCriacao() =>
            RuleFor(d => d.DataHoraCriacao)
                .NotEmpty().WithMessage("A data e hora de criação são obrigatórias.");
    }
}
