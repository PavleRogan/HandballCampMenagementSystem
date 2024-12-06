using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Players.Dtos;
using HCMS.Application.Seasons.Dtos;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Players.Queries.GetAll
{
    internal class GetPlayerByIdQueryHandler(IPlayersRepository playersRepository, IMapper mapper, ILogger<GetPlayerByIdQueryHandler> logger ) : IRequestHandler<GetPlayerByIdQuery, PlayerDto>
    {
        public async Task<PlayerDto> Handle(GetPlayerByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting player wit id: {@player}", request.Id);

            var player = await playersRepository.GetById(request.Id);

            if (player == null)
            {
                throw new NotFoundException($"Player with id: {request.Id} not found.");

            }

            var playerDto = mapper.Map<PlayerDto>(player);

            return playerDto;
        }
    }
}
