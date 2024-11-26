using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Groups.Dtos;
using HCMS.Application.Seasons.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Groups.Queries.GetAll
{
    internal class GetAllGroupsQueryHandler(IGroupsRepository groupsRepository,IMapper mapper) : IRequestHandler<GetAllGroupsQuery, IEnumerable<GroupDto>>
    {
        public async Task<IEnumerable<GroupDto>> Handle(GetAllGroupsQuery request, CancellationToken cancellationToken)
        {
            var groups = await groupsRepository.GetAllAsync();
            var groupDtos = mapper.Map<IEnumerable<GroupDto>>(groups);
            return groupDtos;
        }
    }
}
