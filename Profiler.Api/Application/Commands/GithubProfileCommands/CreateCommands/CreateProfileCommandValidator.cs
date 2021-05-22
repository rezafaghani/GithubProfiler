using FluentValidation;
using Microsoft.Extensions.Logging;

namespace Profiler.Api.Application.Commands.GithubProfileCommands.CreateCommands
{
    /// <summary>
    /// this class use to validate profile submitted request
    /// </summary>
    public class CreateProfileCommandValidator:AbstractValidator<CreateProfileCommand>
    {
        public CreateProfileCommandValidator(ILogger<CreateProfileCommandValidator> logger)
        {
            //email should be exist in request
            RuleFor(order => order.Email).NotEmpty().WithMessage("No email found");
            //name of profile can not be empty 
            RuleFor(order => order.Name).NotEmpty().WithMessage("No name found");
            //github account name can not be empty
            RuleFor(order => order.GithubAccount).NotEmpty().WithMessage("No account found");
            //email should be valid
            RuleFor(order => order.Email).EmailAddress().WithMessage("Not valid email");
            logger.LogTrace("----- INSTANCE CREATED - {ClassName}", GetType().Name);
        }
    }
}