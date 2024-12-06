using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Seasons.Dtos;
using HCMS.Domain.Entities;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Queries.GetSeasonById
{
    internal class GetSeasonByIdQueryHandler(ISeasonsRepository seasonsRepository, IMapper mapper, ILogger<GetSeasonByIdQueryHandler> logger) : IRequestHandler<GetSeasonByIdQuery, SeasonDto>
    {
        public async Task<SeasonDto> Handle(GetSeasonByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting season wit id: {@shift}", request.Id);

            var season = await seasonsRepository.GetById(request.Id);

            if (season == null)
            {
                throw new NotFoundException($"Season with id: {request.Id} not found.");

            }

            var seasonDto = mapper.Map<SeasonDto>(season);
          
            return seasonDto;

        }
    }
}
