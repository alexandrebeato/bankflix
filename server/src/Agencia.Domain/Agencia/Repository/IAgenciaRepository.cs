using Core.Domain.Interfaces;

namespace Agencia.Domain.Agencia.Repository
{
    public interface IAgenciaRepository : IRepository<Agencia>
    {
        Agencia ObterPorCnpj(string cnpj);
    }
}
