using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Octokit;
using Profiler.Domain.AggregatesModel;

namespace Profiler.Api.Application.Commands.GithubProfileCommands.CreateRepoCommands
{
    public class CreateRepoCommandHandler : IRequestHandler<CreateRepoCommand, bool>
    {
        private readonly IProfileRepoRepository _repository;

        public CreateRepoCommandHandler(IProfileRepoRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(CreateRepoCommand request, CancellationToken cancellationToken)
        {
            var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
            var repo = await github.Repository.GetAllForUser(request.AccountName);
            if (repo != null)
            {
                var repoList = repo.Select(x => new ProfileRepo
                {
                    Name = x.Name,
                    GithubProfileId = request.ProfileId
                }).ToList();
                var existList =(await _repository.GetByProfileIdAsync(request.ProfileId)).Select(x=>x.Name);
                var repoNotDuplicates = repoList.Where(x => !existList.Contains(x.Name)).ToList();
                if (repoNotDuplicates.Any())
                {
                    await _repository.AddRange(repoNotDuplicates);
                    return await _repository.UnitOfWork.SaveEntitiesAsync(cancellationToken);    
                }

                return true;

            }

            return false;
        }
    }
}