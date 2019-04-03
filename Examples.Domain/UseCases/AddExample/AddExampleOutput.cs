using Examples.Data.Entities;
using Examples.Domain.Models;

namespace Examples.Domain.UseCases
{
    public class AddExampleOutput : IOutput
    {
        public ExampleModel AddedExample { get; set; }

        public AddExampleOutput(Example createdExample)
        {
            AddedExample = new ExampleModel(createdExample);
        }
    }
}
