namespace Examples.Domain.UseCases
{
    public class AddExampleInput : IInput
    {
        public string ExampleString { get; set; }
        public bool? ExampleBoolean { get; set; }
        public int? ExampleInt { get; set; }
    }
}
