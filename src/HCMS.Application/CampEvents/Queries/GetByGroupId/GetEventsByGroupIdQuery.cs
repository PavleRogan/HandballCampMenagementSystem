using HCMS.Application.CampEvents.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Queries.GetByGroupId
{
    public class GetEventsByGroupIdQuery : IRequest<IEnumerable<CampEventDto>>
    {
        public Guid GroupId { get; set; }
    }
}
