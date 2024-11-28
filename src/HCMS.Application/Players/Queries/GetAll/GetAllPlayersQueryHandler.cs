using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Players.Dtos;
using HCMS.Application.Seasons.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Players.Queries.GetAll
{
    internal class GetAllPlayersQueryHandler(IPlayersRepository playersRepository, IMapper mapper) : IRequestHandler<GetAllPlayersQuery, IEnumerable<PlayerDto>>
    {
        public async Task<IEnumerable<PlayerDto>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {

            var players = await playersRepository.GetAllAsync();
            var playersDto = mapper.Map<IEnumerable<PlayerDto>>(players);
            return playersDto;

        }
    }
}
