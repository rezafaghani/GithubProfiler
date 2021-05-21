using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Profiler.Api.Application.Commands.GithubProfileCommands.CreateCommands
{
    public class CreateProfileCommandValidator:AbstractValidator<CreateProfileCommand>
    {
        public CreateProfileCommandValidator(ILogger<CreateProfileCommandValidator> logger)
        {
            RuleFor(order => order.Email).NotEmpty().WithMessage("No email found");
            RuleFor(order => order.Name).NotEmpty().WithMessage("No name found");
            RuleFor(order => order.GithubAccount).NotEmpty().WithMessage("No account found");
            RuleFor(order => order.Email).EmailAddress().WithMessage("Not valid email");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}