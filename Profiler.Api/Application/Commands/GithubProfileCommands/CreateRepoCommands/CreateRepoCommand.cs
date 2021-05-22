using MediatR;

namespace Profiler.Api.Application.Commands.GithubProfileCommands.CreateRepoCommands
{
    public class CreateRepoCommand : IRequest<bool>
    {
        public long ProfileId { get; set; }
        public string AccountName { get; set; }
    }
}