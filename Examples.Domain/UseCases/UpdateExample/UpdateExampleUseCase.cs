using Examples.Data;
using Examples.Data.Entities;
using System;

namespace Examples.Domain.UseCases
{
    public interface IUpdateExampleUseCase : IUseCase<UpdateExampleInput, UpdateExampleOutput>
    {
    }

    public class UpdateExampleUseCase : IUpdateExampleUseCase
    {
        private readonly IReadWriteRepository<Example> exampleRepository;

        public UpdateExampleUseCase(IReadWriteRepository<Example> exampleRepository)
        {
            this.exampleRepository = exampleRepository;
        }

        public UpdateExampleOutput Execute(UpdateExampleInput input)
        {
            var existingExample = exampleRepository.Find(input.Id);

            if (existingExample == null)
                throw new NullReferenceException($"Example met id '{input.Id}' niet gevonden.");

            existingExample.ExampleString = input.ExampleString;
            existingExample.ExampleInt = input.ExampleInt;
            existingExample.ExampleBoolean = input.ExampleBoolean;

            exampleRepository.Update(existingExample);

            return new UpdateExampleOutput();
        }
    }
}
