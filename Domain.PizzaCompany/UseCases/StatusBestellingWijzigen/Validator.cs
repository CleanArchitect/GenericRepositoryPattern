using Domain.Repositories;
using FluentValidation;

namespace Domain.PizzaCompany
{
    public sealed class StatusBestellingWijzigenValidator : AbstractValidator<StatusBestellingWijzigenInput>
    {
        public StatusBestellingWijzigenValidator(IReadRepository<Bestelling> bestellingenRepository)
        {
            RuleFor(input => input.BestellingId).Exists(bestellingenRepository);
        }
    }
}
