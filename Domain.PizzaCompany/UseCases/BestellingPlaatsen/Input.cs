using Domain.UseCases;
using System.Collections.Generic;

namespace Domain.PizzaCompany
{
    public sealed class BestellingPlaatsenInput : IInput
    {
        public int KlantId { get; set; }
        public IEnumerable<int> PizzaIds { get; set; }
    }
}
