using Domain.UseCases;
using System.Collections.Generic;
using System.Linq;

namespace Domain.PizzaCompany
{
    public sealed class PizzaMenuBekijkenOutput : IOutput
    {
        public IEnumerable<PizzaKeuzeModel> PizzaKeuzes { get; set; }

        internal PizzaMenuBekijkenOutput(IEnumerable<Pizza> pizzas)
        {
            PizzaKeuzes = pizzas.Select(pizza => new PizzaKeuzeModel(pizza));
        }
    }
}
