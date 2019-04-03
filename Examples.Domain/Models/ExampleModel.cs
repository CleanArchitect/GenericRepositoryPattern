using System;
using Examples.Data.Entities;

namespace Examples.Domain.Models
{
    public class ExampleModel : BaseModel
    {
        public string ExampleString { get; set; }

        public DateTime? ExampleDatumStart { get; set; }

        public DateTime? ExampleDatumEinde{ get; set; }

        public bool? ExampleBoolean { get; set; }

        public int? ExampleInt { get; set; }

        public ExampleModel(Example example) : base(example)
        {
            this.ExampleString = example.ExampleString;
            this.ExampleDatumStart = example.DatumStart?.ToLocalTime();
            this.ExampleDatumEinde = example.DatumEinde?.ToLocalTime();
            this.ExampleBoolean = example.ExampleBoolean;
            this.ExampleInt = example.ExampleInt;
        }
    }
}
