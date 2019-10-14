using System;

namespace Movimentacoes.Domain.Contas.Repository
{
    public interface IContaRepository
    {
        Conta ObterPorNumeroComDigitoVerificador(string numero, string digitoVerificador);
        Conta ObterPorId(Guid id);
        Conta ObterPorCliente(Guid clienteId);
    }
}
