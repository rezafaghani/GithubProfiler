namespace Profiler.Api.Application.Queries.GithubProfileQueries
{
    public class SearchModel
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string GithubAccount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}