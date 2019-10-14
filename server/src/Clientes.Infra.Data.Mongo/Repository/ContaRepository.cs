using Clientes.Domain.Contas;
using Clientes.Domain.Contas.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;

namespace Clientes.Infra.Data.Mongo.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(IConfiguration configuration) : base(configuration) { }

        public Conta ObterPorCliente(Guid clienteId)
        {
            return _mongoCollection.Find(c => c.ClienteId == clienteId).FirstOrDefault();
        }

        public Conta ObterPorNumero(string numero)
        {
            return _mongoCollection.Find(c => c.Numero == numero).FirstOrDefault();
        }
    }
}
