using System;

namespace Examples.Data.Entities
{
    public class PeriodEntity : Entity
    {
        public DateTime? DatumStart { get; set; }

        public DateTime? DatumEinde { get; set; }
    }
}
