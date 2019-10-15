using Core.Domain.Utils;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bankflix.API.Models.Clientes.Clientes
{
    public class CadastrarClienteViewModel
    {
        public CadastrarClienteViewModel()
        {
            Id = Guid.NewGuid();
            DataHoraCriacao = DateTime.UtcNow;
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome completo é obrigatório.")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [MinLength(11, ErrorMessage = "O CPF deve ser válido.")]
        [MaxLength(11, ErrorMessage = "O CPF deve ser válido.")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail deve ser válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; }

        public string SenhaCriptografada
        {
            get
            {
                return Criptografia.CriptografarComMD5(Senha);
            }
        }

        public DateTime DataHoraCriacao { get; set; }
    }
}
