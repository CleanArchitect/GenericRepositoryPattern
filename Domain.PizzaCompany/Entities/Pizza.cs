using Domain.Entities;
using System;

namespace Domain.PizzaCompany
{
    public class Pizza : Entity
    {
        public string Code { get; private set; }
        public string Naam { get; private set; }
        public decimal Prijs { get; private set; }
        public TimeSpan Bereidingstijd { get; private set; }

        protected Pizza(){ }

        internal Pizza(string code, string naam, decimal prijs, TimeSpan bereidingstijd)
        {
            Code = code;
            Naam = naam;
            Prijs = prijs;
            Bereidingstijd = bereidingstijd;
        }

        internal bool MetNaam(string zoekNaam)
        {
            if (string.IsNullOrEmpty(zoekNaam))
                return true;
            
            var equals = Naam.Equals(zoekNaam, StringComparison.CurrentCultureIgnoreCase);
            var startsWith = Naam.StartsWith(zoekNaam, StringComparison.CurrentCultureIgnoreCase);
            var contains = Naam.Contains(zoekNaam, StringComparison.CurrentCultureIgnoreCase);

            return equals || startsWith || contains;
        }
    }
}
