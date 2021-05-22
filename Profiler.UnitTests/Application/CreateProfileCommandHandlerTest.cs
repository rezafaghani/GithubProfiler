using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Profiler.Api.Application.Commands.GithubProfileCommands.CreateCommands;
using Profiler.Domain.AggregatesModel;
using Xunit;

namespace Profiler.Test.Application
{
    public class CreateProfileCommandHandlerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<IProfileRepository> _mockProfileRepository;

        public CreateProfileCommandHandlerTest()
        {
            _mediator = new Mock<IMediator>();
            _mockProfileRepository = new Mock<IProfileRepository>();
        }

        [Fact]
        public async Task Handle_return_false_if_profile_is_not_persisted()
        {
            var fakeProfileCmd = FakeProfileRequest(new Dictionary<string, object>
            {
                ["Email"] = "rfaghani91@gmail.com",
                ["Name"] = "reza",
                ["Organization"] = "",
                ["PhoneNumber"] = "09111704858",
                ["GithubAccount"] = "rezafaghani"
            });

            _mockProfileRepository.Setup(profileRepo => profileRepo.GetAsync(It.IsAny<long>()));
            //  .Returns(Task.FromResult<GithubProfile>(FakeProfile()));
            _mockProfileRepository.Setup(profileRepo => profileRepo.UnitOfWork.SaveChangesAsync(default))
                .Returns(Task.FromResult(1));


            //Act
            var handler = new CreateProfileCommandHandler(_mockProfileRepository.Object, _mediator.Object);
            var cltToken = new CancellationToken();
            var result = await handler.Handle(fakeProfileCmd, cltToken);

            //Assert
            Assert.False(result);
        }

        private GithubProfile FakeProfile()
        {
            return new()
            {
                Deleted = false,
                Email = "rfaghani91@gmail.com",
                Name = "reza",
                Organization = "",
                PhoneNumber = "09111704858",
                GithubAccount = "rezafaghani"
            };
        }

        private CreateProfileCommand FakeProfileRequest(Dictionary<string, object> args = null)
        {
            return new()
            {
                Email = args != null && args.ContainsKey("Email") ? (string) args["Email"] : null,
                Name = args != null && args.ContainsKey("Name") ? (string) args["Name"] : null,
                Organization = args != null && args.ContainsKey("Organization") ? (string) args["Organization"] : null,
                GithubAccount = args != null && args.ContainsKey("GithubAccount")
                    ? (string) args["GithubAccount"]
                    : null,
                PhoneNumber = args != null && args.ContainsKey("PhoneNumber") ? (string) args["PhoneNumber"] : null
            };
        }
    }
}