using Clientes.Domain.Clientes.Enums;
using System;

namespace Bankflix.API.Models.Clientes.Clientes
{
    public class ClienteViewModel
    {
        public Guid Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public SituacaoCliente Situacao { get; set; }
        public DateTime DataHoraCriacao { get; set; }
    }
}
