using System.Threading.Tasks;
using Profiler.Domain.SeedWork;

namespace Profiler.Domain.AggregatesModel
{
    public interface IProfileRepository : IRepository<GithubProfile>
    {
        Task<GithubProfile> GetByEmail(string email);
    }
}