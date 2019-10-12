using Core.Domain.Models;
using System;

namespace Clientes.Domain.Contas
{
    public class Conta : Entity<Conta>
    {
        private Conta() { }

        public Guid ClienteId { get; private set; }
        public string Numero { get; private set; }
        public string DigitoVerificador { get; private set; }
        public long SaldoDisponivel { get; private set; }
        public DateTime DataHoraCriacao { get; private set; }

        public void AdicionarValorSaldo(long valor) => SaldoDisponivel += valor;

        public void RemoverValorSaldo(long valor)
        {
            if (SaldoDisponivel < valor)
                throw new InvalidOperationException("Saldo disponível menor que o valor solicitado para remoção.");

            SaldoDisponivel -= valor;
        }

        public override bool EstaConsistente()
        {
            throw new NotImplementedException();
        }

        public static class Factory
        {
            public static Conta CriarNovaConta(Guid id, Guid clienteId, string numero, string digitoVerificador, DateTime dataHoraCriacao) =>
                new Conta
                {
                    Id = id,
                    ClienteId = clienteId,
                    Numero = numero,
                    DigitoVerificador = digitoVerificador,
                    SaldoDisponivel = 0,
                    DataHoraCriacao = dataHoraCriacao
                };
        }
    }
}
