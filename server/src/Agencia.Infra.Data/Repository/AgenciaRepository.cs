using Agencia.Domain.Agencia.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Linq;

namespace Agencia.Infra.Data.Mongo.Repository
{
    public class AgenciaRepository : Repository<Domain.Agencia.Agencia>, IAgenciaRepository
    {
        public AgenciaRepository(IConfiguration configuration) : base(configuration) { }

        public Domain.Agencia.Agencia ObterPorCnpj(string cnpj)
        {
            return _mongoCollection.Find(a => a.Cnpj == cnpj).FirstOrDefault();
        }

        public void ConfigurarAgencia(Guid id, string razaoSocial, string nomeFantasia, string cnpj, string senha, string numeroAgencia, string digitoVerificador)
        {
            var agenciasExistente = ObterTodos();

            if (agenciasExistente.Any())
                return;

            var agencia = Domain.Agencia.Agencia.Factory.CriarAgenciaPadrao(id, razaoSocial, nomeFantasia, cnpj, senha, numeroAgencia, digitoVerificador);
            Inserir(agencia);
        }
    }
}
