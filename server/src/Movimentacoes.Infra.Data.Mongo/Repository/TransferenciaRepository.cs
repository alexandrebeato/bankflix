using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Movimentacoes.Domain.Transferencias;
using Movimentacoes.Domain.Transferencias.Repository;
using System;
using System.Collections.Generic;

namespace Movimentacoes.Infra.Data.Mongo.Repository
{
    public class TransferenciaRepository : Repository<Transferencia>, ITransferenciaRepository
    {
        public TransferenciaRepository(IConfiguration configuration) : base(configuration) { }

        public List<Transferencia> ObterPorClienteDestino(Guid clienteId)
        {
            return _mongoCollection.Find(t => t.ContaDestino.Cliente.Id == clienteId).ToList();
        }

        public List<Transferencia> ObterPorClienteOrigem(Guid clienteId)
        {
            return _mongoCollection.Find(t => t.ContaOrigem.Cliente.Id == clienteId).ToList();
        }

        public List<Transferencia> ObterPorContaDestino(Guid contaId)
        {
            return _mongoCollection.Find(t => t.ContaDestino.Id == contaId).ToList();
        }

        public List<Transferencia> ObterPorContaOrigem(Guid contaId)
        {
            return _mongoCollection.Find(t => t.ContaOrigem.Id == contaId).ToList();
        }
    }
}
