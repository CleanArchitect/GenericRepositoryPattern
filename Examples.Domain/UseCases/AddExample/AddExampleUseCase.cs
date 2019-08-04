using System.Threading.Tasks;
using Examples.Domain.Entities;

namespace Examples.Domain.UseCases
{
    public interface IAddExampleUseCase : IUseCase<AddExampleInput, AddExampleOutput>
    {
    }

    internal sealed class AddExampleUseCase : IAddExampleUseCase
    {
        private readonly IReadWriteRepository<Example> exampleRepository;

        public AddExampleUseCase(IReadWriteRepository<Example> exampleRepository)
        {
            this.exampleRepository = exampleRepository;
        }

        public async Task<AddExampleOutput> ExecuteAsync(AddExampleInput input)
        {
            var newExample = new Example(input.ExampleString, input.ExampleBoolean, input.ExampleInt);
            
            await exampleRepository.AddAsync(newExample);

            return new AddExampleOutput(newExample);
        }
    }
}
