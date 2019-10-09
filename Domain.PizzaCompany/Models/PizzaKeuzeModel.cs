using Domain.Models;

namespace Domain.PizzaCompany
{
    public sealed class PizzaKeuzeModel : BaseModel
    {
        public string Code { get; set; }
        public string Naam { get; }
        public decimal Prijs { get; }

        internal PizzaKeuzeModel(Pizza pizza) : base(pizza)
        {
            Code = pizza.Code;
            Naam = pizza.Naam;
            Prijs = pizza.Prijs;
        }
    }
}
