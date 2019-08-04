using System;

namespace Examples.Domain.UseCases
{
    public sealed class GetExamplesInput : IInput
    {
        public int? Id { get; set; }

        public string ExampleString { get; set; }

        public bool? ExampleBoolean { get; set; }

        public int? ExampleInt { get; set; }

        public DateTime? DatumVanaf { get; set; }

        public DateTime? DatumTm { get; set; }
    }
}
