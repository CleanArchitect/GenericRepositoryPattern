using Examples.Domain.Entities;
using System.Threading.Tasks;

namespace Examples.Domain.UseCases
{
    public interface IGetExamplesUseCase : IUseCase<GetExamplesInput, GetExamplesOutput>
    {
    }

    internal sealed class GetExamplesUseCase : IGetExamplesUseCase
    {
        private readonly IReadRepository<Example> exampleRepository;

        public GetExamplesUseCase(IReadRepository<Example> exampleRepository)
        {
            this.exampleRepository = exampleRepository;
        }

        public async Task<GetExamplesOutput> ExecuteAsync(GetExamplesInput input)
        {
            if (input.Id.HasValue)
                return new GetExamplesOutput(await exampleRepository.FindAsync(input.Id.Value));
            
            var examples = await exampleRepository.FindAllAsync(example => 
                example.HasExampleBoolean(input.ExampleBoolean) &&
                example.HasExampleString(input.ExampleString) &&
                example.HasExampleInt(input.ExampleInt) &&
                example.IsComplete());

            return new GetExamplesOutput(examples);
        }
    }
}
