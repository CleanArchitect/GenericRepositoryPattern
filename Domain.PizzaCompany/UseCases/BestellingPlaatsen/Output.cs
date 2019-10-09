using Domain.UseCases;

namespace Domain.PizzaCompany
{
    public sealed class BestellingPlaatsenOutput : IOutput
    {
        public BestellingModel NieuweBestelling { get; set; }

        internal BestellingPlaatsenOutput(Bestelling bestelling)
        {
            NieuweBestelling = new BestellingModel(bestelling);
        }
    }
}
