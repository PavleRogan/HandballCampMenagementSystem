using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Commands.Delete
{
    public class DeleteShiftCommand : IRequest
    {
        public Guid Id { get; set; }
        public DeleteShiftCommand(Guid id) {
            Id = id;
        }
    }
}
