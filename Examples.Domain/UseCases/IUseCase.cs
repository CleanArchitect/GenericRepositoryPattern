using System.Threading.Tasks;

namespace Examples.Domain
{
    public interface IInput { }

    public interface IOutput { }

    public interface IUseCase { }

    public interface IUseCase<in TInput, TOutput> : IUseCase where TInput : IInput where TOutput : IOutput
    {
        Task<TOutput> ExecuteAsync(TInput input);
    }
}
