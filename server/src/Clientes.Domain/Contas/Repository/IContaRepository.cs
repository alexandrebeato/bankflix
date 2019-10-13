using Core.Domain.Interfaces;
using System;

namespace Clientes.Domain.Contas.Repository
{
    public interface IContaRepository : IRepository<Conta>
    {
        Conta ObterPorCliente(Guid clienteId);
        Conta ObterPorNumero(string numero);
    }
}
