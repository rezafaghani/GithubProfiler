using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Octokit;
using Profiler.Api.Application.Commands.GithubProfileCommands.CreateRepoCommands;
using Profiler.Domain.AggregatesModel;
using Profiler.Domain.SeedWork;

namespace Profiler.Api.Application.Commands.GithubProfileCommands.CreateCommands
{
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, bool>
    {
        private readonly IProfileRepository _profileRepository;
        private readonly IMediator _mediator;

        public CreateProfileCommandHandler(IProfileRepository profileRepository, IMediator mediator)
        {
            _profileRepository = profileRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var github = new GitHubClient(new ProductHeaderValue("MyAmazingApp"));
            var user = await github.User.Get(request.GithubAccount);
            if (user==null)
            {
                return false;
            }

           
            var existProfile = await _profileRepository.GetByEmail(request.Email); ;
         
            if (existProfile != null)
            {
                existProfile.Email = request.Email;
                existProfile.Name = request.Name;
                existProfile.Organization = request.Organization;
                existProfile.GithubAccount = request.GithubAccount;
                existProfile.PhoneNumber = request.PhoneNumber;
                _profileRepository.Update(existProfile);
                var updateResult= (await _profileRepository.UnitOfWork.SaveChangesAsync(cancellationToken)) > 0;
                await _mediator.Send(new CreateRepoCommand
                {
                    AccountName = request.GithubAccount,
                    ProfileId= existProfile.Id
                }, cancellationToken);
                return updateResult;
            }

            var createDto = new GithubProfile
            {
                Email = request.Email,
                Name = request.Name,
                Organization = request.Organization,
                GithubAccount = request.GithubAccount,
                PhoneNumber = request.PhoneNumber
            };
            _profileRepository.Add(createDto);
            var result= await _profileRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
             await _mediator.Send(new CreateRepoCommand
             {
                 AccountName = request.GithubAccount,
                ProfileId= createDto.Id
             }, cancellationToken);
             return result;
        }
    }
}