using Core.Domain.Models;

namespace Core.Domain.Validations
{
    public abstract class DomainSpecification<T> where T : Entity<T>
    {
        protected readonly T _entidade;

        protected DomainSpecification(T entidade)
        {
            _entidade = entidade;
        }

        public abstract bool IsValid();
    }
}
