using MediatR;

namespace Profiler.Api.Application.Commands.GithubProfileCommands.CreateCommands
{
    public class CreateProfileCommand:IRequest<bool>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Organization { get; set; }
        public string GithubAccount { get; set; }
    }
}