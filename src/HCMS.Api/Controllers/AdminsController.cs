using HCMS.Application.Admins.Commands.Create;
using HCMS.Application.Admins.Commands.Delete;
using HCMS.Application.Admins.Commands.Update;
using HCMS.Application.Admins.Dtos;
using HCMS.Application.Admins.Queries.GetAll;
using HCMS.Application.Admins.Queries.GetById;
using HCMS.Application.Players.Commands.Delete;
using HCMS.Application.Players.Commands.Update;
using HCMS.Application.Players.Dtos;
using HCMS.Application.Players.Queries.GetAll;
using HCMS.Application.Seasons.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AdminsController : ControllerBase
    {
        private IMediator _mediator;
        public AdminsController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAdminCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDto>> GetById([FromRoute] Guid id)
        {
            var admin = await _mediator.Send(new GetAdminByIdQuery(id));
            return Ok(admin);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDto>>> GetAll()
        {
            var admins = await _mediator.Send(new GetAllAdminsQuery());
            return Ok(admins);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteAdminCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAdminCommand command)
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
