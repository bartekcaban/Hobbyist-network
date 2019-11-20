using Hobbyist_Network.Application.Commands.Event;
using Hobbyist_Network.Application.Queries.Event;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hobbyist_Network.WebAPI.Controllers
{
    [Route("api/event")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private IMediator _mediator;

        public EventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddEventCommand command)
        {
            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "Event created" });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] UpdateEventCommand command)
        {
            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "Event updated" });
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] DeleteEventCommand command)
        {
            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "Event deleted" });
        }

        [HttpGet("get")]
        public IActionResult Get([FromQuery] GetEventsQuery query)
        {
            var events = _mediator.Send(query);

            if (events.Result == null)
            {
                return BadRequest("Error");
            }
            return Ok(events);
        }

        [HttpGet("get-by-user-id")]
        public IActionResult GetByUserId([FromQuery] GetEventsByUserIdQuery query)
        {
            var events = _mediator.Send(query);

            if (events.Result == null)
            {
                return BadRequest("Error");
            }
            return Ok(events);
        }
    }
}