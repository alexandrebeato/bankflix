using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Movimentacoes.Domain.Contas;
using Movimentacoes.Domain.Contas.Repository;
using System;

namespace Movimentacoes.Infra.Data.Mongo.Repository
{
    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(IConfiguration configuration) : base(configuration) { }

        public Conta ObterPorCliente(Guid clienteId)
        {
            return _mongoCollection.Find(c => c.ClienteId == clienteId).FirstOrDefault();
        }

        public Conta ObterPorNumeroComDigitoVerificador(string numero, string digitoVerificador)
        {
            return _mongoCollection.Find(c => c.Numero == numero && c.DigitoVerificador == digitoVerificador).FirstOrDefault();
        }
    }
}
