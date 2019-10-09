using Domain.Repositories;
using FluentValidation;

namespace Domain.PizzaCompany
{
    public sealed class BestellingPlaatsenValidator : AbstractValidator<BestellingPlaatsenInput>
    {
        public BestellingPlaatsenValidator(IReadRepository<Klant> klantenRepository, IReadRepository<Pizza> pizzasRepository)
        {
            RuleFor(input => input.KlantId).Exists(klantenRepository);
            RuleFor(input => input.PizzaIds).NotEmpty();
            RuleForEach(input => input.PizzaIds).Exists(pizzasRepository);
        }
    }
}
