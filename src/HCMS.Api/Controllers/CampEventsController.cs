using HCMS.Application.CampEvents.Commands.Create;
using HCMS.Application.CampEvents.Commands.Delete;
using HCMS.Application.CampEvents.Commands.SubscribeCoachToEvent;
using HCMS.Application.CampEvents.Commands.SubscribeGroupToEvent;
using HCMS.Application.CampEvents.Commands.Update;
using HCMS.Application.CampEvents.Dtos;
using HCMS.Application.CampEvents.Queries.GetAll;
using HCMS.Application.CampEvents.Queries.GetByGroupId;
using HCMS.Application.CampEvents.Queries.GetById;
using HCMS.Application.Groups.Commands.Create;
using HCMS.Application.Groups.Commands.Delete;
using HCMS.Application.Groups.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CampEventsController : ControllerBase
    {
        private IMediator _mediator;
        public CampEventsController(IMediator mediator) { 
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCampEvent([FromBody] CreateCampEventCommand command)
        {

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCampEventById), new { id = id }, id);

        }

        [HttpPost("/{eventId}/subscribe-group/{groupId}")]
        public async Task<IActionResult> SubscribeGroupToEvent(Guid eventId, Guid groupId)
        {
            await _mediator.Send(new SubscribeGroupToEventCommand(eventId, groupId));
            return Ok();
        }

        [HttpPost("{eventId}/subscribe/{coachId}")]
        public async Task<IActionResult> SubscribeCoachToEvent(Guid eventId, Guid coachId)
        {
            await _mediator.Send(new SubscribeCoachToEventCommand(eventId, coachId));

            return Ok(new { Message = "Coach successfully subscribed to the event." });
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCampEvents()
        {
            var campEvents = await _mediator.Send(new GetAllEventsQuery());
            return Ok(campEvents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCampEventById(Guid id)
        {
            var campEvent = await _mediator.Send(new GetEventByIdQuery { CampEventId = id });

            return Ok(campEvent);
        }

        [HttpGet("group/{groupId}")]
        public async Task<ActionResult<IEnumerable<CampEventDto>>> GetEventsByGroupId(Guid groupId)
        {
            var query = new GetEventsByGroupIdQuery { GroupId = groupId };
            var result = await _mediator.Send(query);

            return Ok(result); 
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCampEventCommand command)
        {
            if (command.CampEventId != id)
            {
                return BadRequest("ID in URL does not match ID in request body.");

            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(Guid id)
        {
            await _mediator.Send(new DeleteCampEventCommand(id));
            return NoContent();
        }
    }
}
