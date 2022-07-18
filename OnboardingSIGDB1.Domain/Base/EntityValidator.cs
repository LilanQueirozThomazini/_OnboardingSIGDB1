using FluentValidation;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnboardingSIGDB1.Domain.Base
{
    public abstract class EntityValidator<TEntity> : AbstractValidator<TEntity>
        where TEntity : EntityValidator<TEntity>
    {
        [NotMapped]
        public ValidationResult ValidationResult { get; protected set; }

        public abstract bool Validar();
    }
}
