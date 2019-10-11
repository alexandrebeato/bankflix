using Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Core.Domain.Interfaces
{
    public interface IRepository<T> where T : Entity<T>
    {
        void Inserir(T entidade);
        void Atualizar(T entidade);
        void Excluir(Guid id);
        T ObterPorId(Guid id);
        List<T> ObterTodos();
        List<T> Buscar(Expression<Func<T, bool>> predicate);
    }
}
