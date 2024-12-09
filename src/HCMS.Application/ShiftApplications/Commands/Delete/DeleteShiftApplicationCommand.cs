using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Commands.Delete
{
    public class DeleteShiftApplicationCommand : IRequest
    {
        public Guid PlayerId { get; set; }
        public Guid ShiftId { get; set; }

        public DeleteShiftApplicationCommand(Guid playerId,Guid shiftId)
        {
            PlayerId = playerId;

            ShiftId = shiftId;
        }
    }
}
