using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Movimentacoes.Domain.Clientes;
using Movimentacoes.Domain.Clientes.Repository;
using System;

namespace Movimentacoes.Infra.Data.Mongo.Repository
{
    public class ClienteRepository : ReadOnlyRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration) { }

        public Cliente ObterPorId(Guid id)
        {
            return _mongoCollection.Find(c => c.Id == id).FirstOrDefault();
        }
    }
}
