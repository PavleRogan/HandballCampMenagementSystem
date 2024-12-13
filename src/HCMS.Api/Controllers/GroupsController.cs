
using HCMS.Application.Groups.Commands.Create;
using HCMS.Application.Groups.Commands.Delete;
using HCMS.Application.Groups.Commands.Update;
using HCMS.Application.Groups.Queries.GetAll;
using HCMS.Application.Groups.Queries.GetById;
using HCMS.Application.Groups.Dtos;

using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HCMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class GroupsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup([FromBody] CreateGroupCommand command)
        {

            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetGroupById), new { id = id }, id);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetGroupById(Guid id)
        {
            var shift = await _mediator.Send(new GetGroupByIdQuery(id));

            return Ok(shift);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetAll()
        {
            var group = await _mediator.Send(new GetAllGroupsQuery());
            return Ok(group);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateGroupCommand command)
        {
            if (command.GroupId != id)
            {
                return BadRequest("ID in URL does not match ID in request body.");

            }

            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup(Guid id)
        {
            await _mediator.Send(new DeleteGroupCommand(id));
            return NoContent();
        }
    }
}
