using Core.Domain.Models;
using MongoDB.Bson.Serialization.Attributes;

namespace Movimentacoes.Domain.Clientes
{
    [BsonIgnoreExtraElements]
    public class Cliente : Entity<Cliente>
    {
        public string NomeCompleto { get; private set; }
        public string Cpf { get; private set; }

        public override bool EstaConsistente()
        {
            return true;
        }
    }
}
