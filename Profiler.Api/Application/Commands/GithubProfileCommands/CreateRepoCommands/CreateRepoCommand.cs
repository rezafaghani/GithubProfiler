using MediatR;

namespace Profiler.Api.Application.Commands.GithubProfileCommands.CreateRepoCommands
{
    public class CreateRepoCommand : IRequest<bool>
    {
        /// <summary>
        /// id of profile that created in our db
        /// </summary>
        public long ProfileId { get; set; }
        /// <summary>
        /// account name of github
        /// </summary>
        public string AccountName { get; set; }
    }
}