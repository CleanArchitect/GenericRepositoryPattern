using Examples.Data;
using Examples.Data.Entities;

namespace Examples.Domain.UseCases
{
    public interface IAddExampleUseCase : IUseCase<AddExampleInput, AddExampleOutput>
    {
    }

    public class AddExampleUseCase : IAddExampleUseCase
    {
        private readonly IReadWriteRepository<Example> exampleRepository;

        public AddExampleUseCase(IReadWriteRepository<Example> exampleRepository)
        {
            this.exampleRepository = exampleRepository;
        }

        public AddExampleOutput Execute(AddExampleInput input)
        {
            var newExample = new Example
            {
                ExampleString = input.ExampleString,
                ExampleBoolean = input.ExampleBoolean,
                ExampleInt = input.ExampleInt
            };

            exampleRepository.Add(newExample);

            return new AddExampleOutput(newExample);
        }
    }
}
