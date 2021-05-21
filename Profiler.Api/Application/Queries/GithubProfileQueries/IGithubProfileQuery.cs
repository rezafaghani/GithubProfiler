using System.Collections.Generic;
using System.Threading.Tasks;

namespace Profiler.Api.Application.Queries.GithubProfileQueries
{
    public interface IGithubProfileQuery
    {
        Task<IEnumerable<SearchResultModel>> SearchContacts(SearchModel input);
    }
}