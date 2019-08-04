using Examples.Domain.Entities;

namespace Examples.Domain.UseCases
{
    public sealed class AddExampleOutput : IOutput
    {
        public ExampleModel AddedExample { get; set; }

        public AddExampleOutput(Example createdExample)
        {
            AddedExample = new ExampleModel(createdExample);
        }
    }
}
