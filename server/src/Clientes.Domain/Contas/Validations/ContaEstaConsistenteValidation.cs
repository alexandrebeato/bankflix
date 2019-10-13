using Core.Domain.Validations;
using FluentValidation;

namespace Clientes.Domain.Contas.Validations
{
    public class ContaEstaConsistenteValidation : DomainValidator<Conta>
    {
        public ContaEstaConsistenteValidation(Conta entidade) : base(entidade)
        {
            ValidarId();
            ValidarClienteId();
            ValidarNumero();
            ValidarDigitoVerificador();
            ValidarSaldoDisponivel();
            ValidarDataHoraCriacao();
        }

        private void ValidarId() =>
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O ID é obrigatório.");

        private void ValidarClienteId() =>
            RuleFor(c => c.ClienteId)
                .NotEmpty().WithMessage("A conta deve estar vinculada a um cliente.");

        private void ValidarNumero() =>
            RuleFor(c => c.Numero)
                .NotEmpty().WithMessage("O número da conta é obrigatório.")
                .MaximumLength(15).WithMessage("O número da conta deve possuir no máximo 15 caracteres.");

        private void ValidarDigitoVerificador() =>
            RuleFor(c => c.DigitoVerificador)
                .NotEmpty().WithMessage("O dígito verificador é obrigatório.")
                .MaximumLength(2).WithMessage("O dígito verificador deve possuir no máximo 2 caracteres.");

        private void ValidarSaldoDisponivel() =>
            RuleFor(c => c.SaldoDisponivel)
                .GreaterThanOrEqualTo(0).WithMessage("O saldo não pode ser negativo.");

        private void ValidarDataHoraCriacao() =>
            RuleFor(c => c.DataHoraCriacao)
                .NotEmpty().WithMessage("A data e hora de cadastros são obrigatórias.");
    }
}
