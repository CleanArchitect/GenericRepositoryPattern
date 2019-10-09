using System.ComponentModel;

namespace Domain.PizzaCompany
{
    public enum BestellingStatus
    {
        [DisplayName("Ontvangen")]
        Ontvangen = 1,

        [DisplayName("In behandeling")]
        InBehandeling = 2,

        [DisplayName("In de oven")]
        InOven = 3,

        [DisplayName("Klaar")]
        Klaar = 4
    }
}
