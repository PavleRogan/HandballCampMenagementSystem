using HCMS.Application.Groups.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Groups.Queries.GetAll
{
    public class GetAllGroupsQuery : IRequest<IEnumerable<GroupDto>>
    {
    }
}
