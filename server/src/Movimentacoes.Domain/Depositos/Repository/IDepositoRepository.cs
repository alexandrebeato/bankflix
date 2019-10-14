using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Movimentacoes.Domain.Depositos.Repository
{
    public interface IDepositoRepository : IRepository<Deposito>
    {
        List<Deposito> ObterPorConta(Guid contaId);
        List<Deposito> ObterPorCliente(Guid clienteId);
    }
}
