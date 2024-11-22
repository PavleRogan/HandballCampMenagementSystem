using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Commands.Create
{
    public class CreateSeasonCommandHandler(ISeasonsRepository seasonsRepository) : IRequestHandler<CreateSeasonCommand, Guid>
    {
        public async Task<Guid> Handle(CreateSeasonCommand request, CancellationToken cancellationToken)
        {
            var season = new Season
            {
                SeasonId = Guid.NewGuid(),
                Name = request.Name,
                Year = request.Year,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                LocationCity = request.LocationCity
            };

            await seasonsRepository.Create(season);

            return season.SeasonId;
        }
    }
}
