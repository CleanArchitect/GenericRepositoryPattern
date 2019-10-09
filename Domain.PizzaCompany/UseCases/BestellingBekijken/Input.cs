using Domain.UseCases;

namespace Domain.PizzaCompany
{
    public sealed class BestellingBekijkenInput : IInput
    {
        public int Id { get; }

        public BestellingBekijkenInput(int id)
        {
            Id = id;
        }
    }
}
