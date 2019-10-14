using System;

namespace Movimentacoes.Domain.Contas.Repository
{
    public interface IContaRepository
    {
        Conta ObterPorNumero(string numero);
        Conta ObterPorId(Guid id);
        Conta ObterPorCliente(Guid clienteId);
    }
}
