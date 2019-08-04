using Examples.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Examples.Domain.UseCases
{
    public interface IUpdateExampleUseCase : IUseCase<UpdateExampleInput, UpdateExampleOutput>
    {
    }

    internal sealed class UpdateExampleUseCase : IUpdateExampleUseCase
    {
        private readonly IReadWriteRepository<Example> exampleRepository;

        public UpdateExampleUseCase(IReadWriteRepository<Example> exampleRepository)
        {
            this.exampleRepository = exampleRepository;
        }

        public async Task<UpdateExampleOutput> ExecuteAsync(UpdateExampleInput input)
        {
            var existingExample = await exampleRepository.FindAsync(input.Id);

            if (existingExample == null)
                throw new NullReferenceException($"Example met id '{input.Id}' niet gevonden.");

            existingExample.Update(input);

            await exampleRepository.UpdateAsync(existingExample);

            return new UpdateExampleOutput();
        }
    }
}
