using Domain.Models;
using System;

namespace Domain.PizzaCompany
{
    public sealed class BestellingModel : BaseModel
    {
        public Guid Bestelnummer { get; private set; }
        public BestellingStatus Status { get; private set; }
        public DateTime DatumTijdBesteld { get; set; }
        public DateTime VerwachtteDatumTijdKlaar { get; private set; }

        internal BestellingModel(Bestelling bestelling) : base(bestelling)
        {
            Bestelnummer = bestelling.Uuid;
            Status = bestelling.Status;
            VerwachtteDatumTijdKlaar = bestelling.BerekenVerwachtteDatumTijdKlaar();
            DatumTijdBesteld = bestelling.DatumBestelling;
        }
    }
}
