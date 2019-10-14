using Clientes.Domain.Clientes;
using Clientes.Domain.Clientes.Enums;
using Clientes.Domain.Clientes.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Clientes.Infra.Data.Mongo.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(IConfiguration configuration) : base(configuration) { }

        public Cliente ObterPorCpf(string cpf)
        {
            return _mongoCollection.Find(c => c.Cpf == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return _mongoCollection.Find(c => c.Email == email).FirstOrDefault();
        }

        public List<Cliente> ObterPorSituacao(SituacaoCliente situacao)
        {
            return _mongoCollection.Find(c => c.Situacao == situacao).ToList();
        }
    }
}
