using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Profiler.Api.Application.Commands.GithubProfileCommands.CreateCommands;

namespace Profiler.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Create")]
        [MapToApiVersion("1")]
        [ProducesResponseType(type: typeof(bool),statusCode: (int) HttpStatusCode.OK)]
        [ProducesResponseType(type: typeof(bool),statusCode: (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateProfileCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
    }
}