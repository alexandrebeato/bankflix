using Core.Domain.Models;
using FluentValidation;

namespace Core.Domain.Validations
{
    public abstract class DomainValidator<T> : AbstractValidator<T> where T : Entity<T>
    {
        protected readonly T _entidade;

        protected DomainValidator(T entidade)
        {
            _entidade = entidade;
        }
    }
}
