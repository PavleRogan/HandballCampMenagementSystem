using AutoMapper;
using HCMS.Application.Admins.Dtos;
using HCMS.Application.Coaches.Dtos;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Coaches.Queries.GetById
{
    internal class GetCoachByIdQueryHandler(ICoachesRepository coachesRepository, IMapper mapper) : IRequestHandler<GetCoachByIdQuery, CoachDto>
    {
        public async Task<CoachDto> Handle(GetCoachByIdQuery request, CancellationToken cancellationToken)
        {
            var coach = await coachesRepository.GetById(request.Id);

            if (coach == null)
            {
                throw new NotFoundException($"Coach with id: {request.Id} not found.");

            }

            var dto = mapper.Map<CoachDto>(coach);

            return dto;
        }
    }
}
