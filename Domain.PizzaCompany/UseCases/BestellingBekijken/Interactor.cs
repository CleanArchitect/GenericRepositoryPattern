using Domain.Repositories;
using System.Threading.Tasks;

namespace Domain.PizzaCompany
{
    internal sealed class BestellingBekijkenUseCase : IBestellingBekijkenUseCase
    {
        private readonly IReadRepository<Bestelling> bestellingenRepository;

        public BestellingBekijkenUseCase(IReadRepository<Bestelling> bestellingenRepository)
        {
            this.bestellingenRepository = bestellingenRepository;
        }

        public async Task<BestellingBekijkenOutput> ExecuteAsync(BestellingBekijkenInput input)
        {
            var bestelling = await bestellingenRepository.FindAsync(input.Id);

            return new BestellingBekijkenOutput(bestelling);
        }
    }
}
