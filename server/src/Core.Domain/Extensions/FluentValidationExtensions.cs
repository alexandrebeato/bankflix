using Core.Domain.Models;
using Core.Domain.Validations;
using FluentValidation;

namespace Core.Domain.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, TProperty> IsValid<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, DomainSpecification<T> predicate) where T : Entity<T>
        {
            return ruleBuilder.Must(p => predicate.IsValid());
        }
    }
}
