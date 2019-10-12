using Clientes.Domain.Clientes.Enums;
using Clientes.Domain.Clientes.Validations;
using Core.Domain.Models;
using System;

namespace Clientes.Domain.Clientes
{
    public class Cliente : Entity<Cliente>
    {
        private Cliente() { }

        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public string Senha { get; private set; }
        public SituacaoCliente Situacao { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }

        public void Aprovar() => Situacao = SituacaoCliente.Aprovado;

        public void Recusar() => Situacao = SituacaoCliente.Recusado;

        public override bool EstaConsistente()
        {
            ValidationResult = new ClienteEstaConsistenteValidation(this).Validate(this);
            return ValidationResult.IsValid;
        }

        public static class Factory
        {
            public static Cliente CriarNovoCliente(Guid id, string nomeCompleto, string cpf, DateTime dataNascimento, string email, string telefone, string senha, DateTime dataHoraCriacao) =>
                new Cliente
                {
                    Id = id,
                    NomeCompleto = nomeCompleto,
                    Cpf = cpf,
                    DataNascimento = dataNascimento,
                    Email = email,
                    Telefone = telefone,
                    Senha = senha,
                    Situacao = SituacaoCliente.Pendente,
                    DataHoraCriacao = dataHoraCriacao
                };
        }
    }
}
