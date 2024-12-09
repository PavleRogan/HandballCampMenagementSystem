using HCMS.Application.Seasons.Dtos;
using HCMS.Application.ShiftApplications.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Queries.GetById
{
    public class GetShiftApplicationByIdsQuery : IRequest<ShiftApplicationDto>
    {

        public Guid ShiftId { get; set; }
        public Guid PlayerId { get; set; }

        public GetShiftApplicationByIdsQuery(Guid playerId, Guid shiftId)
        {
            this.PlayerId = playerId;
            this.ShiftId = shiftId;
        }
    }
    
}
