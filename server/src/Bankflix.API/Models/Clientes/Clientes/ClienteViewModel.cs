using Clientes.Domain.Clientes.Enums;
using System;

namespace Bankflix.API.Models.Clientes.Clientes
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; }
        public string Cpf { get; }
        public DateTime DataNascimento { get; }
        public string Email { get; }
        public string Telefone { get; }
        public string Senha { get; }
        public SituacaoCliente Situacao { get; }
        public DateTime DataHoraCriacao { get; }
    }
}
