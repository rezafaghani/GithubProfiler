using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Profiler.Api.Application.Commands.GithubProfileCommands.CreateCommands;
using Profiler.Api.Application.Queries.GithubProfileQueries;

namespace Profiler.Api.Controllers
{
    [ApiVersion("1")]
    [ApiVersion("2")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IGithubProfileQuery _githubProfileQuery;

        public ContactsController(IMediator mediator, IGithubProfileQuery githubProfileQuery)
        {
            _mediator = mediator;
            _githubProfileQuery = githubProfileQuery;
        }

        [HttpPost()]
        [MapToApiVersion("1")]
        [ProducesResponseType(type: typeof(bool),statusCode: (int) HttpStatusCode.OK)]
        [ProducesResponseType(type: typeof(bool),statusCode: (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateProfileCommand input)
        {
            return Ok(await _mediator.Send(input));
        }
        [HttpGet()]
        [MapToApiVersion("1")]
        [ProducesResponseType(type: typeof(IEnumerable<SearchResultModel>),statusCode: (int) HttpStatusCode.OK)]
        [ProducesResponseType(type: typeof(IEnumerable<SearchResultModel>),statusCode: (int) HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Search([FromQuery] SearchModel input)
        {
           return Ok(await _githubProfileQuery.SearchContacts(input));
        }
    }
}