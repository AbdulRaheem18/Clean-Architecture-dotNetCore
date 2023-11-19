using FOA.Application.Features.Users.Queries;
using FOA.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FOA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator) {
            _mediator = mediator;
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("GetUserList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Get()
        {
            var result = await _mediator.Send(new GetUsersRequest());
            return Ok(result);
        }

    }
}
