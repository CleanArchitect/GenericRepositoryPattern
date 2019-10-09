using Domain.UseCases;

namespace Domain.PizzaCompany
{
    public sealed class BestellingBekijkenOutput : IOutput
    {
        public BestellingModel Bestelling { get; }

        public BestellingBekijkenOutput(Bestelling bestelling)
        {
            Bestelling = new BestellingModel(bestelling);
        }
    }
}
