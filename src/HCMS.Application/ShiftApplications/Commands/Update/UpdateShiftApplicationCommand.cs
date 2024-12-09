using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Commands.Update
{
    public class UpdateShiftApplicationCommand : IRequest
    {
        public Guid PlayerId { get; set; }
        public Guid ShiftId { get; set; }

        public string StatusOfApplication { get; set; } = null!;

    }
}
