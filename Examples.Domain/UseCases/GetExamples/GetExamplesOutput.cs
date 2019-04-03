using Examples.Domain.Models;
using Examples.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Domain.UseCases
{
    public class GetExamplesOutput : IOutput
    {
        public List<ExampleModel> Examples { get; } = new List<ExampleModel>();

        public GetExamplesOutput(Example example)
        {
            Examples.Add(new ExampleModel(example));
        }

        public GetExamplesOutput(IEnumerable<Example> examples)
        {
            Examples.AddRange(examples.Select(example => new ExampleModel(example)));
        }
    }
}
