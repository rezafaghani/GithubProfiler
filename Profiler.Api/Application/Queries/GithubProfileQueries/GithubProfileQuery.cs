using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace Profiler.Api.Application.Queries.GithubProfileQueries
{
    public class GithubProfileQuery : IGithubProfileQuery
    {
        private string _connectionString = string.Empty;

        public GithubProfileQuery(string constr)
        {
            _connectionString = !string.IsNullOrWhiteSpace(constr)
                ? constr
                : throw new ArgumentNullException(nameof(constr));
        }

        public async Task<IEnumerable<SearchResultModel>> SearchContacts(SearchModel input)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var parameterDictionary = new Dictionary<string, object>
                {
                    {"@PageNumber", input.PageSize * input.PageNumber},
                    {"@PageSize", input.PageSize}
                };

                var query = new StringBuilder("select * from profiling.githubprofiles ");
                if (!string.IsNullOrWhiteSpace(input.Email))
                {
                    parameterDictionary.Add("@Email", input.Email);
                    query.Append(" and Email=@Email ");
                }

                if (!string.IsNullOrWhiteSpace(input.Name))
                {
                    parameterDictionary.Add("@Name", input.Name);
                    query.Append(" and Name=@Name  ");
                }

                if (!string.IsNullOrWhiteSpace(input.Organization))
                {
                    parameterDictionary.Add("@Organization", input.Organization);
                    query.Append(" and Organization = @Organization  ");
                }

                if (!string.IsNullOrWhiteSpace(input.GithubAccount))
                {
                    parameterDictionary.Add("@GithubAccount", input.GithubAccount);
                    query.Append(" and GithubAccount = @GithubAccount  ");
                }

                if (!string.IsNullOrWhiteSpace(input.PhoneNumber))
                {
                    parameterDictionary.Add("@PhoneNumber", input.PhoneNumber);
                    query.Append(" and PhoneNumber = @PhoneNumber  ");
                }

                connection.Open();
                var parameters = new DynamicParameters(parameterDictionary);
                var totalCountResult = await connection.QueryAsync<SearchResultModel>(query.ToString(), parameters);
                query.Append(" limit @PageSize offset @PageNumber ;");
                var profileResult = connection.Query<SearchResultModel>(query.ToString(), parameters);
                return profileResult.Select(x => new SearchResultModel
                {
                    Id = x.Id,
                    Deleted = x.Deleted,
                    Email = x.Email,
                    Name = x.Name,
                    Organization = x.Organization,
                    GithubAccount = x.GithubAccount,
                    PhoneNumber = x.PhoneNumber,
                    CreateDateTime = x.CreateDateTime,
                    DeleteDateTime = x.DeleteDateTime,
                    UpdateDateTime = x.UpdateDateTime,
                    PageNumber = input.PageNumber,
                    PageSize = input.PageSize,
                    TotalCount = totalCountResult.Count()
                }).ToList();
            }
        }
    }
}