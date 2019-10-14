using Core.Domain.ValueObjects;
using System;

namespace Movimentacoes.Domain.Transferencias.ValueObjects
{
    public class Cliente : ValueObject<Cliente>
    {
        private Cliente() { }

        public Guid Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }

        public static class Factory
        {
            public static Cliente CriarCliente(Guid id, string nomeCompleto, string cpf) =>
                new Cliente
                {
                    Id = id,
                    NomeCompleto = nomeCompleto,
                    Cpf = cpf
                };
        }
    }
}
