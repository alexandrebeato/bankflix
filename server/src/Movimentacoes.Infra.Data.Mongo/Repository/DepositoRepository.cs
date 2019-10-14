using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Movimentacoes.Domain.Depositos;
using Movimentacoes.Domain.Depositos.Repository;
using System;
using System.Collections.Generic;

namespace Movimentacoes.Infra.Data.Mongo.Repository
{
    public class DepositoRepository : Repository<Deposito>, IDepositoRepository
    {
        public DepositoRepository(IConfiguration configuration) : base(configuration) { }

        public List<Deposito> ObterPorCliente(Guid clienteId)
        {
            return _mongoCollection.Find(d => d.Conta.Cliente.Id == clienteId).ToList();
        }

        public List<Deposito> ObterPorConta(Guid contaId)
        {
            return _mongoCollection.Find(d => d.Conta.Id == contaId).ToList();
        }
    }
}
