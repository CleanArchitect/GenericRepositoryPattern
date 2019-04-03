namespace Examples.Domain.UseCases
{
    public interface IInput
    {
    }

    public interface IOutput
    {
    }

    public interface IUseCase<in TInput, out TOutput> where TInput : IInput where TOutput : IOutput
    {
        TOutput Execute(TInput input);
    }
}
