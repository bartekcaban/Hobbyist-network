using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Hobbyist_Network.Application.Commands.User;
using Hobbyist_Network.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hobbyist_Network.WebAPI.Controllers
{
    [Route("api/")]
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

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserQuery query)
        {
            var user = _mediator.Send(query);

            if (user.Result == null)
            {
                return BadRequest("Wrong email or password");
            }
            return Ok(user);
        }
    }
}