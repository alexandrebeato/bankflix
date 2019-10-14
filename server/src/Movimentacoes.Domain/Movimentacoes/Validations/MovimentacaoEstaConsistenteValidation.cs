using Core.Domain.Validations;
using FluentValidation;

namespace Movimentacoes.Domain.Movimentacoes.Validations
{
    public class MovimentacaoEstaConsistenteValidation : DomainValidator<Movimentacao>
    {
        public MovimentacaoEstaConsistenteValidation(Movimentacao entidade) : base(entidade)
        {
            ValidarId();
            ValidarConta();
            ValidarTipo();
            ValidarVinculo();
            ValidarValor();
            ValidarDataHoraCriacao();
        }

        private void ValidarId() =>
            RuleFor(m => m.Id)
                .NotEmpty().WithMessage("O ID é obrigatório.");

        private void ValidarConta()
        {
            RuleFor(m => m.Conta)
                .NotNull().WithMessage("É obrigatório informar a conta da movimentação.");

            When(m => m.Conta != null, () =>
            {
                RuleFor(m => m.Conta.Id)
                    .NotEmpty().WithMessage("É obrigatório informar o ID da conta");

                RuleFor(m => m.Conta.Numero)
                    .NotEmpty().WithMessage("É obrigatório informar o número da conta.");

                RuleFor(m => m.Conta.DigitoVerificador)
                    .NotEmpty().WithMessage("É obrigatório informar o dígito verificador da conta.");

                RuleFor(m => m.Conta.Cliente)
                    .NotNull().WithMessage("É obrigatório informar o cliente da conta.");

                When(m => m.Conta.Cliente != null, () =>
                {
                    RuleFor(m => m.Conta.Cliente.Id)
                        .NotEmpty().WithMessage("É obrigatório informar o ID do cliente.");

                    RuleFor(m => m.Conta.Cliente.NomeCompleto)
                        .NotEmpty().WithMessage("É obrigatório informar o nome completo do cliente.");

                    RuleFor(m => m.Conta.Cliente.Cpf)
                        .NotEmpty().WithMessage("É obrigatório informar o CPF do cliente.");
                });
            });
        }

        private void ValidarTipo() =>
            RuleFor(m => m.Tipo)
                .NotNull().WithMessage("O tipo da movimentação é obrigatória.");

        private void ValidarVinculo()
        {
            RuleFor(m => m.Vinculo)
                .NotNull().WithMessage("É obrigatório possuir um vínculo.");

            When(m => m.Vinculo != null, () =>
            {
                RuleFor(m => m.Vinculo.Tipo)
                    .NotNull().WithMessage("O vínculo deve possuir um tipo.");

                RuleFor(m => m.Vinculo.VinculadoId)
                    .NotEmpty().WithMessage("O vínculo deve estar vinculado a algo.");
            });
        }

        private void ValidarValor() =>
            RuleFor(m => m.Valor)
                .GreaterThan(0).WithMessage("O valor da movimentação deve ser maior que 0 (zero).");

        private void ValidarDataHoraCriacao() =>
            RuleFor(m => m.DataHoraCriacao)
                .NotEmpty().WithMessage("A data e hora de criação são obrigatórias.");
    }
}
