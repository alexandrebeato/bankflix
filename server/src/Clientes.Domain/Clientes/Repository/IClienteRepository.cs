using Clientes.Domain.Clientes.Enums;
using Core.Domain.Interfaces;
using System.Collections.Generic;

namespace Clientes.Domain.Clientes.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Cliente ObterPorEmail(string email);
        Cliente ObterPorCpf(string cpf);
        List<Cliente> ObterPorSituacao(SituacaoCliente situacao); 
    }
}
