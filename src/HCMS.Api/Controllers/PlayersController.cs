using HCMS.Application.Players.Commands.Delete;
using HCMS.Application.Players.Commands.Update;
using HCMS.Application.Players.Dtos;
using HCMS.Application.Players.Queries.GetAll;
using HCMS.Application.Seasons.Commands.Create;
using HCMS.Application.Seasons.Commands.Delete;
using HCMS.Application.Seasons.Commands.Update;
using HCMS.Application.Seasons.Dtos;
using HCMS.Application.Seasons.Queries.GetAllSeasons;
using HCMS.Application.Seasons.Queries.GetSeasonById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class PlayersController : ControllerBase
    {
        private IMediator _mediator;
        public PlayersController(IMediator mediator)
        {
            this._mediator = mediator;
        }

   

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayerDto>> GetById([FromRoute] Guid id)
        {
            var player = await _mediator.Send(new GetPlayerByIdQuery(id));
            return Ok(player);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlayerDto>>> GetAll()
        {
            var players = await _mediator.Send(new GetAllPlayersQuery());
            return Ok(players);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            await _mediator.Send(new DeletePlayerCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePlayerCommand command)
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
