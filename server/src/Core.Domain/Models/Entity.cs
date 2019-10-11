using Core.Domain.Interfaces;
using FluentValidation.Results;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Core.Domain.Models
{
    public abstract class Entity<T> : IEntity where T : Entity<T>
    {
        protected Entity()
        {
            ValidationResult = new ValidationResult();
        }

        public Guid Id { get; protected set; }
        public abstract bool EstaConsistente();

        [BsonIgnore]
        public ValidationResult ValidationResult { get; protected set; }

        public void NewValidationResult(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }

        public void AdicionarErrosValidacao(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                ValidationResult.Errors.Add(error);
            }
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity<T>;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        public static bool operator ==(Entity<T> a, Entity<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity<T> a, Entity<T> b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 451) + Id.GetHashCode();
        }
    }
}
