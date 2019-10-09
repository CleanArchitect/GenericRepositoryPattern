using Domain.UseCases;

namespace Domain.PizzaCompany
{
    public sealed class StatusBestellingWijzigenInput : IInput
    {
        public int BestellingId { get; set; }
        public BestellingStatus Status { get; set; }
    }
}
