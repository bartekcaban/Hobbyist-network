using Hobbyist_Network.Application.Commands.User;
using Hobbyist_Network.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hobbyist_Network.WebAPI.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserCommand command)
        {
            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "Account created" });
        }

        [HttpGet("login")]
        public IActionResult Login([FromQuery] LoginUserQuery query)
        {
            var user = _mediator.Send(query);

            if (user.Result == null)
            {
                return BadRequest("Wrong email or password");
            }
            return Ok(user);
        }
        [HttpPut("update")]
        public IActionResult EditUser(Guid id, [FromBody] UpdateUserCommand command)
        {
            command.Id = id;

            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "User updated" });
        }
    }
}