using System;
using System.Collections.Generic;

namespace Profiler.Api.Application.Queries.GithubProfileQueries
{
    public class SearchResultModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string GithubAccount { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime? DeleteDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public bool Deleted { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public long TotalCount { get; set; }
    }
}