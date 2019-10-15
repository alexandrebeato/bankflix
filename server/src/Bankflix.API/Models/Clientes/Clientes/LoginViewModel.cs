using System.ComponentModel.DataAnnotations;

namespace Bankflix.API.Models.Clientes.Clientes
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "CPF/Senha inválidos")]
        [MinLength(11, ErrorMessage = "CPF/Senha inválidos")]
        [MaxLength(11, ErrorMessage = "CPF/Senha inválidos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "CPF/Senha inválidos")]
        public string Senha { get; set; }
    }
}
