using AutoMapper;
using HCMS.Application.CampEvents.Dtos;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Queries.GetByGroupId
{
    internal class GetEventsByGroupIdQueryHandler(IGroupsRepository groupsRepository,
        ICampEventsRepository campEventsRepository,IMapper mapper) : IRequestHandler<GetEventsByGroupIdQuery, IEnumerable<CampEventDto>>
    {
        public async Task<IEnumerable<CampEventDto>> Handle(GetEventsByGroupIdQuery request, CancellationToken cancellationToken)
        {
            var group = await groupsRepository.GetById(request.GroupId);

            if (group == null)
            {
                throw new NotFoundException("Group not found");
            }

            var events = campEventsRepository.GetByGroupId(request.GroupId);

            var eventDtos = mapper.Map<IEnumerable<CampEventDto>>(events);

            return eventDtos;
        }
    }
}