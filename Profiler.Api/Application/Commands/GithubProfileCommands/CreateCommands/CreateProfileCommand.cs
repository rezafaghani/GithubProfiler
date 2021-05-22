using MediatR;

namespace Profiler.Api.Application.Commands.GithubProfileCommands.CreateCommands
{
    public class CreateProfileCommand:IRequest<bool>
    {
        /// <summary>
        /// name of user
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// user phone number
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// user email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// user organization
        /// </summary>
        public string Organization { get; set; }
        /// <summary>
        /// user account name in github
        /// </summary>
        public string GithubAccount { get; set; }
    }
}