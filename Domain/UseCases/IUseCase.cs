using System.Threading.Tasks;

namespace Domain.UseCases
{
    public interface IUseCase<in TInput, TOutput> where TInput : IInput where TOutput : IOutput
    {
        Task<TOutput> ExecuteAsync(TInput input);
    }
}
