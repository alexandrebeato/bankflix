using Core.Domain.Validations;
using FluentValidation;

namespace Clientes.Domain.Clientes.Validations
{
    public class ClienteEstaConsistenteValidation : DomainValidator<Cliente>
    {
        public ClienteEstaConsistenteValidation(Cliente entidade) : base(entidade)
        {
            ValidarId();
            ValidarNomeCompleto();
            ValidarCpf();
            ValidarDataNascimento();
            ValidarEmail();
            ValidarTelefone();
            ValidarSenha();
            ValidarSituacao();
            ValidarDataHoraCriacao();
        }

        private void ValidarId() =>
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("O ID é obrigatório.");

        private void ValidarNomeCompleto() =>
            RuleFor(c => c.NomeCompleto)
                .NotEmpty().WithMessage("O nome completo é obrigatório")
                .MaximumLength(300).WithMessage("O nome completo deve possuir no máximo 300 caracteres.");

        private void ValidarCpf() =>
            RuleFor(c => CpfValidation.Validar(c.Cpf))
                .Equal(true).WithMessage("O CPF deve ser válido.");

        private void ValidarDataNascimento() =>
            RuleFor(c => c.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é obrigatória.");

        private void ValidarEmail() =>
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório.")
                .EmailAddress().WithMessage("O e-mail deve ser válido.");

        private void ValidarTelefone() =>
            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .MaximumLength(11).WithMessage("O telefone deve ser válido.")
                .MinimumLength(10).WithMessage("O telefone deve ser válido.");

        private void ValidarSenha() =>
            RuleFor(c => c.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória.");

        private void ValidarSituacao() =>
            RuleFor(c => c.Situacao)
                .NotEmpty().WithMessage("A situação deve ser definida.");

        private void ValidarDataHoraCriacao() =>
            RuleFor(c => c.DataHoraCriacao)
                .NotEmpty().WithMessage("A data e hora de criação são obrigatórias.");
    }
}
