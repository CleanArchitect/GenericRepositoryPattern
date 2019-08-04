using Examples.Domain.Entities;
using System;

namespace Examples.Domain.UseCases
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
            ExampleString = example.ExampleString;
            ExampleBoolean = example.ExampleBoolean;
            ExampleInt = example.ExampleInt;
        }
    }
}
