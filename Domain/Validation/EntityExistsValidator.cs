using Domain.Entities;
using Domain.Repositories;
using FluentValidation.Validators;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    internal sealed class EntityExistsValidator<TEntity> : AsyncValidatorBase where TEntity : Entity
    {
        private readonly IReadRepository<TEntity> repository;

        public EntityExistsValidator(IReadRepository<TEntity> repository) : base("Id '{PropertyValue}' niet gevonden.")
        {
            this.repository = repository;
        }

        protected override async Task<bool> IsValidAsync(PropertyValidatorContext context, CancellationToken cancellation)
        {
            return await repository.FindAsync((int)context.PropertyValue) != null;
        }
    }
}
