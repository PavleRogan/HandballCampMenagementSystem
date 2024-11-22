using AutoMapper;
using HCMS.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Commands.Update
{
    internal class UpdateSeasonCommandHandler(ISeasonsRepository seasonsRepository, IMapper mapper) : IRequestHandler<UpdateSeasonCommand>
    {
        public async Task Handle(UpdateSeasonCommand request, CancellationToken cancellationToken)
        {

            var season = await seasonsRepository.GetById(request.SeasonId);
            if (season == null)
            {
                throw new NotImplementedException();

            }

            season.Name = request.Name;
            season.Year = request.Year;
            season.StartDate = request.StartDate;
            season.EndDate = request.EndDate;
            season.LocationCity = request.LocationCity;

            // or  mapper.Map(request, season);
            

            await seasonsRepository.SaveChangesAsync();

        }
    }
}
