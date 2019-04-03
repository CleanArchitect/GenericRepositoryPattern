namespace Examples.Domain.UseCases
{
    public class UpdateExampleInput : IInput
    {
        public int Id { get; set; }
        public string ExampleString { get; set; }
        public bool? ExampleBoolean { get; set; }
        public int? ExampleInt { get; set; }
    }
}
