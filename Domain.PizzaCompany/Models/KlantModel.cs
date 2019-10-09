using Domain.Models;

namespace Domain.PizzaCompany
{
    public class KlantModel : BaseModel
    {
        public string Nummer { get; set; }

        public KlantModel(Klant klant) : base(klant)
        {
            Nummer = klant.Nummer;
        }
    }
}
