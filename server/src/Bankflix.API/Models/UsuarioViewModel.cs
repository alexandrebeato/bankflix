using System;

namespace Bankflix.API.Models
{
    public class UsuarioViewModel
    {
        public Guid Id { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
    }

    public enum TipoUsuario
    {
        Agencia,
        Cliente
    }
}
