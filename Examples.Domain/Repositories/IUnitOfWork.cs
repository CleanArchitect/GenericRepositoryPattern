using System.Threading.Tasks;

namespace Examples.Domain
{
    public interface IUnitOfWork
    {
        Task SaveChangesAsync();
    }
}
