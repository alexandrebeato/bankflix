using Core.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Movimentacoes.Domain.Transferencias.Repository
{
    public interface ITransferenciaRepository : IRepository<Transferencia>
    {
        List<Transferencia> ObterPorContaOrigem(Guid contaId);
        List<Transferencia> ObterPorClienteOrigem(Guid clienteId);
        List<Transferencia> ObterPorContaDestino(Guid contaId);
        List<Transferencia> ObterPorClienteDestino(Guid clienteId);
    }
}
