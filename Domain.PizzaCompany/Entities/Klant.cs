using Domain.Entities;
using System.Collections.Generic;

namespace Domain.PizzaCompany
{
    public class Klant : Entity
    {
        public string Nummer { get; private set; }

        public string Naam { get; private set; }

        public virtual ICollection<Bestelling> Bestellingen { get; private set; } = new HashSet<Bestelling>();

        protected Klant() { }
    }
}
