using HCMS.Application.Seasons.Commands.Create;
using HCMS.Application.Seasons.Commands.Delete;
using HCMS.Application.Seasons.Commands.Update;
using HCMS.Application.Seasons.Dtos;
using HCMS.Application.Seasons.Queries.GetAllSeasons;
using HCMS.Application.Seasons.Queries.GetSeasonById;
using HCMS.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HCMS.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeasonsController : ControllerBase
    {
        private IMediator _mediator;
        public SeasonsController(IMediator mediator) {
        this._mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSeason([FromBody] CreateSeasonCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetSeasonById), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SeasonDto>> GetSeasonById([FromRoute] Guid id)
        {
            var season = await _mediator.Send(new GetSeasonByIdQuery(id));
            return Ok(season);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SeasonDto>>> GetAllSeasons()
        {
            var seasons = await _mediator.Send(new GetAllSeasonsQuery());
            return Ok(seasons);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteSeason([FromRoute] Guid id)
        {
            await _mediator.Send(new DeleteSeasonCommand(id));
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSeason(Guid id, [FromBody] UpdateSeasonCommand command)
        {
            if(command.SeasonId != id) {
                return BadRequest("ID in URL does not match ID in request body.");
            }

            await _mediator.Send(command);
            return NoContent();

        }
    }
}

