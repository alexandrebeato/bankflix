using Agencia.Domain.Agencia.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Agencia.Infra.Data.Mongo.Repository
{
    public class AgenciaRepository : Repository<Domain.Agencia.Agencia>, IAgenciaRepository
    {
        public AgenciaRepository(IConfiguration configuration) : base(configuration) { }

        public Domain.Agencia.Agencia ObterPorCnpj(string cnpj)
        {
            return _mongoCollection.Find(a => a.Cnpj == cnpj).FirstOrDefault();
        }
    }
}
