using Examples.Domain;
using System.Threading.Tasks;

namespace Examples.Data
{
    internal interface IDataContext
    {
        IDataSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;

        Task SaveChangesAsync();
    }
}
