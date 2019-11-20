using Hobbyist_Network.Application.Commands.HobbyCategory;
using Hobbyist_Network.Application.Queries.HobbyCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hobbyist_Network.WebAPI.Controllers
{
    [Route("api/hobby-category")]
    [ApiController]
    public class HobbyCategoryController : ControllerBase
    {
        private IMediator _mediator;

        public HobbyCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] AddHobbyCategoryCommand command)
        {
            var commandResult = _mediator.Send(command);

            if (commandResult.IsFaulted)
            {
                return BadRequest(commandResult.Exception.InnerException.Message);
            }

            return Ok(new { message = "Category created" });
        }

        [HttpGet("get")]
        public IActionResult Get([FromQuery] GetHobbyCategoriesQuery query)
        {
            var categories = _mediator.Send(query);

            if (categories.Result == null)
            {
                return BadRequest("Error");
            }
            return Ok(categories);
        }
    }
}