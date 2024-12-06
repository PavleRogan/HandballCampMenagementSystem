using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Coaches.Commands.Delete
{
    public class DeleteCoachCommand : IRequest
    {
        public Guid Id { get; set; }
        public DeleteCoachCommand(Guid id)
        {
            Id = id;
        }
    }
}
