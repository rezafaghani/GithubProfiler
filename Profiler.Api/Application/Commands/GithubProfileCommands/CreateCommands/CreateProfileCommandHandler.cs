using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Profiler.Api.Application.Commands.GithubProfileCommands.CreateCommands
{
    public class CreateProfileCommandHandler:IRequestHandler<CreateProfileCommand,bool>
    {
        public Task<bool> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}