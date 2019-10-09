namespace Domain.PizzaCompany
{
    public class StatusBestellingGewijzigdEvent : IEvent
    {
        public KlantModel Klant { get; set; }
        public BestellingStatus NieuweStatus { get; set; }

        internal StatusBestellingGewijzigdEvent(Bestelling bestelling)
        {
            NieuweStatus = bestelling.Status;
            Klant = new KlantModel(bestelling.Klant);
        }
    }
}
