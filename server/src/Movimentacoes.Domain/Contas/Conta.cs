using Core.Domain.Models;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Movimentacoes.Domain.Contas
{
    [BsonIgnoreExtraElements]
    public class Conta : Entity<Conta>
    {
        public Guid ClienteId { get; private set; }
        public string Numero { get; private set; }
        public string DigitoVerificador { get; private set; }
        public long SaldoDisponivel { get; private set; }

        public override bool EstaConsistente()
        {
            return true;
        }
    }
}
