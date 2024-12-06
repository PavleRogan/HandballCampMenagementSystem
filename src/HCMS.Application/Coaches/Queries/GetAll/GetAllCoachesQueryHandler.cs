using AutoMapper;
using HCMS.Application.Admins.Dtos;
using HCMS.Application.Coaches.Dtos;
using HCMS.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Coaches.Queries.GetAll
{
    internal class GetAllCoachesQueryHandler(ICoachesRepository coachesRepository, IMapper mapper) : IRequestHandler<GetAllCoachesQuery, IEnumerable<CoachDto>>
    {
        public async Task<IEnumerable<CoachDto>> Handle(GetAllCoachesQuery request, CancellationToken cancellationToken)
        {
            var coaches = await coachesRepository.GetAllAsync();
            var dtos = mapper.Map<IEnumerable<CoachDto>>(coaches);
            return dtos;
        }
    }
}
