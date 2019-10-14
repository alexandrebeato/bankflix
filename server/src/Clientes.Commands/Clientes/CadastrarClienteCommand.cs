using Core.Domain.Commands;
using System;

namespace Clientes.Commands.Clientes
{
    public class CadastrarClienteCommand : Command
    {
        public CadastrarClienteCommand(Guid id, string nomeCompleto, string cpf, DateTime dataNascimento, string email, string telefone, string senha, DateTime dataHoraCriacao)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            Email = email;
            Telefone = telefone;
            Senha = senha;
            DataHoraCriacao = dataHoraCriacao;
        }

        public Guid Id { get; }
        public string NomeCompleto { get; }
        public string Cpf { get; }
        public DateTime DataNascimento { get; }
        public string Email { get; }
        public string Telefone { get; }
        public string Senha { get; }
        public DateTime DataHoraCriacao { get; }
    }
}
