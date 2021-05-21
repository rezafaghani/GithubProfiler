using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Profiler.Domain.SeedWork
{
    public interface IRepository<T> where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
        T Add(T entity, long createdBy = 0);
        Task AddRange(List<T> entity);
        T Update(T entity);
        T Delete(T entity);
        IQueryable<T> GetAll();
        Task<T> FindAsync(T entity);
    }
}
