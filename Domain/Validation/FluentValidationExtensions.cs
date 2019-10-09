using Domain.Entities;
using Domain.Repositories;
using FluentValidation;

namespace Domain
{
    public static class FluentValidationExtensions
    {
        public static IRuleBuilderOptions<T, int> Exists<T, TEntity>(this IRuleBuilder<T, int> ruleBuilder, IReadRepository<TEntity> repository) where TEntity : Entity
        {
            return ruleBuilder
                .NotEqual(0)
                .SetValidator(new EntityExistsValidator<TEntity>(repository));
        }
    }
}
