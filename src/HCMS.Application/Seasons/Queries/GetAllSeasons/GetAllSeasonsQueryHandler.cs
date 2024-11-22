using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Seasons.Dtos;
using HCMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Queries.GetAllSeasons
{
    internal class GetAllSeasonsQueryHandler(ISeasonsRepository seasonsRepository, IMapper mapper) : IRequestHandler<GetAllSeasonsQuery, IEnumerable<SeasonDto>>
    {
        public async Task<IEnumerable<SeasonDto>> Handle(GetAllSeasonsQuery request, CancellationToken cancellationToken)
        {
            var seasons = await seasonsRepository.GetAllAsync();
            var seasonDtos = mapper.Map<IEnumerable<SeasonDto>>(seasons);
            return seasonDtos;
        }
    }
}
