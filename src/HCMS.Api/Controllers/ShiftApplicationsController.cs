using HCMS.Application.ShiftApplications.Commands.Create;
using HCMS.Application.ShiftApplications.Commands.Delete;
using HCMS.Application.ShiftApplications.Commands.Update;
using HCMS.Application.ShiftApplications.Dtos;
using HCMS.Application.ShiftApplications.Queries.GetAll;
using HCMS.Application.ShiftApplications.Queries.GetById;
using HCMS.Application.Shifts.Commands.Create;
using HCMS.Application.Shifts.Commands.Delete;
using HCMS.Application.Shifts.Commands.Update;
using HCMS.Application.Shifts.Dtos;
using HCMS.Application.Shifts.Queries.GetAll;
using HCMS.Application.Shifts.Queries.GetById;
using HCMS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShiftApplicationsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateShiftApplication([FromBody] CreateShiftApplicationCommand command)
        {

            var id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetShiftApplicationByIds), new { playerId = command.PlayerId, shiftId = command.ShiftId }, null);

        }

        [HttpGet("{playerId}/{shiftId}")]
        public async Task<IActionResult> GetShiftApplicationByIds(Guid playerId, Guid shiftId)
        {
            var query = new GetShiftApplicationByIdsQuery(playerId, shiftId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShiftApplicationDto>>> GetAllShiftApplications()
        {
            var applications = await mediator.Send(new GetAllShiftApplicationsQuery());
            return Ok(applications);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateShiftApplication([FromBody] UpdateShiftApplicationCommand command)
        {
            
            await mediator.Send(command);
            return NoContent(); 
        }

        [HttpDelete("{playerId}/{shiftId}")]
        public async Task<IActionResult> DeleteShiftApplication(Guid playerId, Guid shiftId)
        {
            var command = new DeleteShiftApplicationCommand(playerId, shiftId);
            await mediator.Send(command);
            return NoContent();  
        }
    }
}
