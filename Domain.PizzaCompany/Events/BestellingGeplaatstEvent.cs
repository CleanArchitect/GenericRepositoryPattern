namespace Domain.PizzaCompany
{
    public class BestellingGeplaatstEvent : IEvent
    {
        public BestellingModel NieuweBestelling { get; }

        internal BestellingGeplaatstEvent(Bestelling bestelling)
        {
            NieuweBestelling = new BestellingModel(bestelling);
        }
    }
}
