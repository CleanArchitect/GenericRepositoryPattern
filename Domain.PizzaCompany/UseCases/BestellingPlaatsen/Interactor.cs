using Domain.Repositories;
using Domain.UseCases;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.PizzaCompany
{
    internal sealed class BestellingPlaatsenUseCase : UseCaseBase, IBestellingPlaatsenUseCase
    {
        private readonly IReadRepository<Klant> klantenRepository;
        private readonly IReadRepository<Pizza> pizzasRepository;
        private readonly IReadWriteRepository<Bestelling> bestellingRepository;

        public BestellingPlaatsenUseCase(
            IEventBus eventBus,
            IReadRepository<Klant> klantenRepository,
            IReadRepository<Pizza> pizzasRepository,
            IReadWriteRepository<Bestelling> bestellingRepository) : base(eventBus)
        {
            this.klantenRepository = klantenRepository;
            this.pizzasRepository = pizzasRepository;
            this.bestellingRepository = bestellingRepository;
        }

        public async Task<BestellingPlaatsenOutput> ExecuteAsync(BestellingPlaatsenInput input)
        {
            var klant = await klantenRepository.FindAsync(input.KlantId);
            var findPizzaTasks = input.PizzaIds.Select(pizzaId => pizzasRepository.FindAsync(pizzaId));
            var pizzas = await Task.WhenAll(findPizzaTasks);

            var nieuweBestelling = new Bestelling(klant, pizzas);

            await bestellingRepository.AddAsync(nieuweBestelling);

            await bestellingRepository.UnitOfWork.SaveChangesAsync();

            await EventBus.RaiseEventAsync(new BestellingGeplaatstEvent(nieuweBestelling));

            return new BestellingPlaatsenOutput(nieuweBestelling);
        }
    }
}
