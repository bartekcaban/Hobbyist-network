using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hobbyist_Network.Application.Commands.Contact;
using Hobbyist_Network.Application.Queries.Contact;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hobbyist_Network.WebAPI.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("not-match")]
        public IActionResult Add([FromBody] NotMatchCommand command)
        {
            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "Not matched" });
        }

        [HttpPost("match")]
        public IActionResult Match([FromBody] MatchCommand command)
        {
            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "Matched" });
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromQuery] DeleteContactCommand command)
        {
            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "Contact deleted" });
        }

        [HttpGet("get")]
        public IActionResult Get([FromQuery] GetContactsByUserIdQuery query)
        {
            var contacts = _mediator.Send(query);

            if (contacts.Result == null)
            {
                return BadRequest("Error");
            }
            return Ok(contacts);
        }
    }
}