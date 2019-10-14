using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Movimentacoes.Domain.Movimentacoes;
using Movimentacoes.Domain.Movimentacoes.Repository;
using System;
using System.Collections.Generic;

namespace Movimentacoes.Infra.Data.Mongo.Repository
{
    public class MovimentacaoRepository : Repository<Movimentacao>, IMovimentacaoRepository
    {
        public MovimentacaoRepository(IConfiguration configuration) : base(configuration) { }

        public List<Movimentacao> ObterPorCliente(Guid clienteId)
        {
            return _mongoCollection.Find(m => m.Conta.Cliente.Id == clienteId).ToList();
        }
    }
}
