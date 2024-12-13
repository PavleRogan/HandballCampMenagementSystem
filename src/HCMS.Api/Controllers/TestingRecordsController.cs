using HCMS.Application.Shifts.Commands.Create;
using HCMS.Application.Shifts.Commands.Delete;
using HCMS.Application.Shifts.Commands.Update;
using HCMS.Application.Shifts.Dtos;
using HCMS.Application.Shifts.Queries.GetAll;
using HCMS.Application.Shifts.Queries.GetById;
using HCMS.Application.TestingRecords.Commands.Create;
using HCMS.Application.TestingRecords.Commands.Delete;
using HCMS.Application.TestingRecords.Commands.Update;
using HCMS.Application.TestingRecords.Dtos;
using HCMS.Application.TestingRecords.Queries.GetAll;
using HCMS.Application.TestingRecords.Queries.GetById;
using HCMS.Application.TestingRecords.Queries.GetByPlayerId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TestingRecordsController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateShift([FromBody] CreateRecordCommand command)
        {

            var id = await mediator.Send(command);
            return CreatedAtAction(nameof(GetRecordById), new { recordId = id }, id);

        }

        [HttpGet("{recordId}")]
        public async Task<ActionResult<TestingRecordDto>> GetRecordById(Guid recordId)
        {
            var r = await mediator.Send(new GetRecordByIdQuery(recordId));

            return Ok(r);
        }
        [HttpGet("player/{playerId}")]
        public async Task<ActionResult<IEnumerable<TestingRecordDto>>> GetRecordsByPlayerId(Guid playerId)
        {
            var r = await mediator.Send(new GetRecordByPlayerIdQuery(playerId));
            return Ok(r);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<TestingRecordDto>>> GetAll()
        {
            var r = await mediator.Send(new GetAllRecordsQuery());
            return Ok(r);
        }

        [HttpPut("{recordId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid recordId, [FromBody] UpdateRecordCommand command)
        {
            if (command.TestingRecordId != recordId)
            {
                return BadRequest("ID in URL does not match ID in request body.");

            }

            await mediator.Send(command);
            return NoContent();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{recordId}")]
        public async Task<IActionResult> DeleteShift(Guid recordId)
        {
            await mediator.Send(new DeleteRecordCommand(recordId));
            return NoContent();
        }

        
    }
}
