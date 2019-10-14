using System;

namespace Movimentacoes.Domain.Clientes.Repository
{
    public interface IClienteRepository
    {
        Cliente ObterPorId(Guid id);
    }
}
