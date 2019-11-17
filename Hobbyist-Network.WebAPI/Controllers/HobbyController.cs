using Hobbyist_Network.Application.Commands.Hobby;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hobbyist_Network.WebAPI.Controllers
{
    [Route("api/hobby")]
    [ApiController]
    public class HobbyController : ControllerBase
    {
        private IMediator _mediator;

        public HobbyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public IActionResult Register([FromBody] AddHobbyCommand command)
        {
            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "Hobby created" });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] UpdateHobbyCommand command)
        {
            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "Hobby updated" });
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] DeleteHobbyCommand command)
        {
            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "Hobby deleted" });
        }
    }
}