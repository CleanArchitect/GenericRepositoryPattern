using Examples.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Domain.UseCases
{
    public sealed class GetExamplesOutput : IOutput
    {
        public List<ExampleModel> Examples { get; } = new List<ExampleModel>();

        public GetExamplesOutput(Example example)
        {
            if (example == null)
            {
                return;
            }

            Examples.Add(new ExampleModel(example));
        }

        public GetExamplesOutput(IEnumerable<Example> examples)
        {
            Examples.AddRange(examples.Select(example => new ExampleModel(example)));
        }
    }
}
