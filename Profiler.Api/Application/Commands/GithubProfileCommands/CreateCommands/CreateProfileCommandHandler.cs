using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Profiler.Domain.AggregatesModel;
using Profiler.Domain.SeedWork;

namespace Profiler.Api.Application.Commands.GithubProfileCommands.CreateCommands
{
    public class CreateProfileCommandHandler : IRequestHandler<CreateProfileCommand, bool>
    {
        private readonly IRepository<GithubProfile> _profileRepository;

        public CreateProfileCommandHandler(IRepository<GithubProfile> profileRepository)
        {
            _profileRepository = profileRepository;
        }

        public async Task<bool> Handle(CreateProfileCommand request, CancellationToken cancellationToken)
        {
            var existProfile = await _profileRepository.GetAll()
                .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(request.Email.ToLower()),
                    cancellationToken: cancellationToken);
            if (existProfile != null)
            {
                existProfile.Email = request.Email;
                existProfile.Name = request.Name;
                existProfile.Organization = request.Organization;
                existProfile.GithubAccount = request.GithubAccount;
                existProfile.PhoneNumber = request.PhoneNumber;
                _profileRepository.Update(existProfile);
                return (await _profileRepository.UnitOfWork.SaveChangesAsync(cancellationToken)) > 0;
            }

            _profileRepository.Add(new GithubProfile
            {
                Email = request.Email,
                Name = request.Name,
                Organization = request.Organization,
                GithubAccount = request.GithubAccount,
                PhoneNumber = request.PhoneNumber
            });
            return await _profileRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        }
    }
}