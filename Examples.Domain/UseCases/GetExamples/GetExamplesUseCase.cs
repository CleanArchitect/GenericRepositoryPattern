using Examples.Data;
using Examples.Domain.Queries;
using Examples.Data.Entities;
using Examples.UseCases.Shared;
using System.Linq;

namespace Examples.Domain.UseCases
{
    public interface IGetExamplesUseCase : IUseCase<GetExamplesInput, GetExamplesOutput>
    {
    }

    public class GetExamplesUseCase : IGetExamplesUseCase
    {
        private readonly IReadRepository<Example> exampleRepository;

        public GetExamplesUseCase(IReadRepository<Example> exampleRepository)
        {
            this.exampleRepository = exampleRepository;
        }

        public GetExamplesOutput Execute(GetExamplesInput input)
        {
            if (input.Id.HasValue)
                return new GetExamplesOutput(exampleRepository.Find(input.Id.Value));

            var examples = exampleRepository.Query()
                .WithExampleString(input.ExampleString, StringOperator.Contains)
                .WithExampleBoolean(input.ExampleBoolean)
                .WithExampleInt(input.ExampleInt, IntOperator.GreaterThan)
                .InPeriod(input.DatumVanaf, input.DatumTm)
                .ToList();

            return new GetExamplesOutput(examples);
        }
    }
}
