using HCMS.Application.Groups.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Groups.Queries.GetById
{
    public class GetGroupByIdQuery : IRequest<GroupDto>
    {
        public Guid Id { get; set; }
        public GetGroupByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
