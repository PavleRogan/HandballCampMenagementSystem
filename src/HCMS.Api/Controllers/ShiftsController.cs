using HCMS.Application.Seasons.Commands.Create;
using HCMS.Application.Seasons.Dtos;
using HCMS.Application.Seasons.Queries.GetAllSeasons;
using HCMS.Application.Shifts.Commands.Create;
using HCMS.Application.Shifts.Commands.Delete;
using HCMS.Application.Shifts.Commands.Update;
using HCMS.Application.Shifts.Dtos;
using HCMS.Application.Shifts.Queries.GetAll;
using HCMS.Application.Shifts.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class ShiftsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateShift([FromBody] CreateShiftCommand command)
        {
          
                var id = await mediator.Send(command);
                return CreatedAtAction(nameof(GetShiftById), new { shiftId = id }, id);

        }

        [HttpGet("{shiftId}")]
        public async Task<ActionResult<ShiftDto>> GetShiftById(Guid shiftId)
        {
            var shift = await mediator.Send(new GetShiftByIdQuery(shiftId));
            
            return Ok(shift);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftDto>>> GetAllShifts()
        {
            var shift = await mediator.Send(new GetAllShiftsQuery());
            return Ok(shift);
        }

        [HttpPut("{shiftId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateShift(Guid shiftId, [FromBody] UpdateShiftCommand command)
        {
            if(command.ShiftId != shiftId)
            {
                return BadRequest("ID in URL does not match ID in request body.");

            }

            await mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{shiftId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteShift(Guid shiftId)
        {
            await mediator.Send(new DeleteShiftCommand(shiftId));
            return NoContent();
        }
    }
}
