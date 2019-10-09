namespace Domain.PizzaCompany
{
    public class PizzaBestelling
    {
        public int Id { get; set; }
        public int BestellingId { get; private set; }
        public int PizzaId { get; private set; }

        public virtual Bestelling Bestelling { get; private set; }
        public virtual Pizza Pizza { get; private set; }

        protected PizzaBestelling(){ }

        internal PizzaBestelling(Bestelling bestelling, Pizza pizza)
        {
            Bestelling = bestelling;
            Pizza = pizza;
        }
    }
}
