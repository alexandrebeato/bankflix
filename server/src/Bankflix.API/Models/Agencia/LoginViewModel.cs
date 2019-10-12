using Core.Domain.Utils;
using System.ComponentModel.DataAnnotations;

namespace Bankflix.API.Models.Agencia
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "CNPJ/Senha inválidos")]
        [MinLength(14, ErrorMessage = "CNPJ/Senha inválidos")]
        [MaxLength(14, ErrorMessage = "CNPJ/Senha inválidos")]
        public string Cnpj { get; set; }

        [Required(ErrorMessage = "CNPJ/Senha inválidos")]
        public string Senha { get; set; }

        public string SenhaCriptografada
        {
            get
            {
                return Criptografia.CriptografarComMD5(Senha);
            }
        }
    }
}
