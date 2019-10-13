using Core.Domain.ValueObjects;
using System;

namespace Movimentacoes.Domain.Depositos.ValueObjects
{
    public class Conta : ValueObject<Conta>
    {
        private Conta() { }

        public Guid Id { get; private set; }
        public string Numero { get; private set; }
        public string DigitoVerificador { get; private set; }
        public Cliente Cliente { get; private set; }

        public void DefinirCliente(Guid id, string nomeCompleto, string cpf) =>
            Cliente = Cliente.Factory.CriarCliente(id, nomeCompleto, cpf);

        public static class Factory
        {
            public static Conta CriarConta(Guid id, string numero, string digitoVerificador, Guid clienteId, string nomeCompleto, string cpf)
            {
                var conta = new Conta
                {
                    Id = id,
                    Numero = numero,
                    DigitoVerificador = digitoVerificador
                };

                conta.DefinirCliente(clienteId, nomeCompleto, cpf);
                return conta;
            }

        }
    }
}
