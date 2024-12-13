using HCMS.Application.Admins.Commands.Create;
using HCMS.Application.Admins.Commands.Delete;
using HCMS.Application.Admins.Commands.Update;
using HCMS.Application.Admins.Dtos;
using HCMS.Application.Admins.Queries.GetAll;
using HCMS.Application.Admins.Queries.GetById;
using HCMS.Application.Coaches.Commands.Create;
using HCMS.Application.Coaches.Commands.Delete;
using HCMS.Application.Coaches.Commands.Update;
using HCMS.Application.Coaches.Dtos;
using HCMS.Application.Coaches.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class CoachesController : ControllerBase
    {
        private IMediator _mediator;
        public CoachesController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCoachCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CoachDto>> GetById([FromRoute] Guid id)
        {
            var coach = await _mediator.Send(new GetCoachByIdQuery(id));
            return Ok(coach);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachDto>>> GetAll()
        {
            var coaches = await _mediator.Send(new GetAllAdminsQuery());
            return Ok(coaches);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteCoachCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCoachCommand command)
        {
            if (command.UserId != id)
            {
                return BadRequest("ID in URL does not match ID in request body.");
            }

            await _mediator.Send(command);
            return NoContent();

        }
    }
}
