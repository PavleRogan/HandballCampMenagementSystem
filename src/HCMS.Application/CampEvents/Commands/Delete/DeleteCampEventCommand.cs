using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Commands.Delete
{
    public class DeleteCampEventCommand : IRequest
    {
        public Guid Id { get; set; }
        public DeleteCampEventCommand(Guid id)
        {
            Id = id;
        }
    }
}
