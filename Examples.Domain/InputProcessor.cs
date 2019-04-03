using System;

namespace Examples.UseCases
{
    public interface IInputProcessor
    {
        TOutput Process<TOutput>(IInput<TOutput> input) where TOutput : IOutputBoundary;
    }

    public class InputProcessor : IInputProcessor
    {
        private readonly IServiceProvider serviceProvider;

        public InputProcessor(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public TOutput Process<TOutput>(IInput input) where TOutput : IOutputBoundary
        {       
            var interactor = serviceProvider.GetService(typeof(IInputBoundary<TInput, TOutput>)) as IInputBoundary<TInput, TOutput>;

            return interactor.Execute(input);
        }
    }
}
