using HCMS.Application.ShiftApplications.Dtos;
using HCMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Commands.Create
{
    public class CreateShiftApplicationCommand : IRequest<ShiftApplicationDto>
    {
        public Guid PlayerId { get; set; }
        public Guid ShiftId { get; set; }
    }
}
