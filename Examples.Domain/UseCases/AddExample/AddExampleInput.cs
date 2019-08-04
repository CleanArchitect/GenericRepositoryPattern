namespace Examples.Domain.UseCases
{
    public sealed class AddExampleInput : IInput
    {
        public string ExampleString { get; set; }
        public bool? ExampleBoolean { get; set; }
        public int? ExampleInt { get; set; }
    }
}
