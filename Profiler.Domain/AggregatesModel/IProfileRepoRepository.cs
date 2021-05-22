using System.Collections.Generic;
using System.Threading.Tasks;
using Profiler.Domain.SeedWork;

namespace Profiler.Domain.AggregatesModel
{
    public interface IProfileRepoRepository :IRepository<ProfileRepo>
    {
        Task<List<ProfileRepo>> GetByProfileIdAsync(long id);
    }
}