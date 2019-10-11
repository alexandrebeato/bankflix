using Core.Domain.Validations;
using FluentValidation;

namespace Agencia.Domain.Agencia.Validations
{
    public class AgenciaEstaConsistenteValidation : DomainValidator<Agencia>
    {
        public AgenciaEstaConsistenteValidation(Agencia entidade) : base(entidade)
        {
            ValidarId();
            ValidarRazaoSocial();
            ValidarNomeFantasia();
            ValidarCnpj();
            ValidarSenha();
            ValidarDadosBancarios();
        }

        private void ValidarId()
        {
            RuleFor(a => a.Id)
                .NotEmpty().WithMessage("O ID é obrigatório.");
        }

        private void ValidarRazaoSocial()
        {
            RuleFor(a => a.RazaoSocial)
                .NotEmpty().WithMessage("A razão social é obrigatória.")
                .MaximumLength(300).WithMessage("A razão social deve conter no máximo 300 caracteres.");
        }

        private void ValidarNomeFantasia()
        {
            RuleFor(a => a.NomeFantasia)
                .NotEmpty().WithMessage("O nome fantasia é obrigatório.")
                .MaximumLength(150).WithMessage("O nome fantasia deve conter no máximo 150 caracteres.");
        }

        private void ValidarCnpj()
        {
            RuleFor(a => CnpjValidation.Validar(a.Cnpj))
                .Equal(true).WithMessage("O CNPJ deve ser válido.");
        }

        private void ValidarSenha()
        {
            RuleFor(a => a.Senha)
                .NotEmpty().WithMessage("A senha é obrigatória.");
        }

        private void ValidarDadosBancarios()
        {
            RuleFor(a => a.DadosBancarios)
                .NotNull().WithMessage("É obrigatório possuir configurações de dados bancários.");
        }
    }
}
