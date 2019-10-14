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

        public Guid Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }
    }
}
