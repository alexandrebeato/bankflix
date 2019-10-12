using Core.Domain.Interfaces;
using System;

namespace Agencia.Domain.Agencia.Repository
{
    public interface IAgenciaRepository : IRepository<Agencia>
    {
        Agencia ObterPorCnpj(string cnpj);
        void ConfigurarAgencia(Guid id, string razaoSocial, string nomeFantasia, string cnpj, string senha, string numeroAgencia, string digitoVerificador);
    }
}
