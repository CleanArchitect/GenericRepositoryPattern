using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Domain.PizzaCompany
{
    public class Bestelling : Entity
    {
        public int KlantId { get; private set; }
        public DateTime DatumBestelling { get; private set; }
        public DateTime? DatumStatusWijziging { get; private set; }
        public BestellingStatus Status { get; private set; }

        public virtual Klant Klant { get; private set; }
        public virtual ICollection<PizzaBestelling> PizzaBestellingen { get; private set; } = new HashSet<PizzaBestelling>();
        
        protected Bestelling(){ }

        internal Bestelling(Klant klant, IEnumerable<Pizza> pizzas)
        {
            Klant = klant;
            Status = BestellingStatus.Ontvangen;
            DatumBestelling = DateTime.Now;
            PizzaBestellingen = pizzas.Select(pizza => new PizzaBestelling(this, pizza)).ToArray();
        }

        internal void WijzigStatus(BestellingStatus nieuweStatus)
        {
            DatumStatusWijziging = DateTime.Now;
            Status = nieuweStatus;
        }

        internal DateTime BerekenVerwachtteDatumTijdKlaar() => DatumBestelling.Add(GetTotaleBereidingstijd());
        
        internal TimeSpan GetTotaleBereidingstijd()
        {
            return PizzaBestellingen
                .Max(pizzaBestelling => pizzaBestelling.Pizza.Bereidingstijd);
        }
    }
}
