using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Groups.Dtos;
using HCMS.Application.Seasons.Dtos;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Groups.Queries.GetById
{
    internal class GetGroupByIdQueryHandler(IGroupsRepository groupsRepository, IMapper mapper) : IRequestHandler<GetGroupByIdQuery, GroupDto>
    {
        public async  Task<GroupDto> Handle(GetGroupByIdQuery request, CancellationToken cancellationToken)
        {
            var g = await groupsRepository.GetById(request.Id);

            if (g == null)
            {
                throw new NotFoundException($"Group with id: {request.Id} not found.");

            }

            var groupDto = mapper.Map<GroupDto>(g);

            return groupDto;
        }
    }
}
