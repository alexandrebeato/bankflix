using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Movimentacoes.Domain.Movimentacoes.Repository
{
    public interface IMovimentacaoRepository : IRepository<Movimentacao>
    {
        List<Movimentacao> ObterPorCliente(Guid clienteId);
    }
}
