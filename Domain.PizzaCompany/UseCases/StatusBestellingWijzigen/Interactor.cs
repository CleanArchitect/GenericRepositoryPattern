using Domain.Repositories;
using Domain.UseCases;
using System.Threading.Tasks;

namespace Domain.PizzaCompany
{
    internal sealed class StatusBestellingWijzigenUseCase : UseCaseBase, IStatusBestellingWijzigenUseCase
    {
        private readonly IReadWriteRepository<Bestelling> bestellingenRepository;

        public StatusBestellingWijzigenUseCase(
            IEventBus eventBus,
            IReadWriteRepository<Bestelling> bestellingenRepository) : base(eventBus)
        {
            this.bestellingenRepository = bestellingenRepository;
        }

        public async Task<StatusBestellingWijzigenOutput> ExecuteAsync(StatusBestellingWijzigenInput input)
        {
            var bestelling = await bestellingenRepository.FindAsync(input.BestellingId);

            bestelling.WijzigStatus(input.Status);

            await bestellingenRepository.UpdateAsync(bestelling);

            await bestellingenRepository.UnitOfWork.SaveChangesAsync();

            await EventBus.RaiseEventAsync(new StatusBestellingGewijzigdEvent(bestelling));

            return new StatusBestellingWijzigenOutput();
        }
    }
}
