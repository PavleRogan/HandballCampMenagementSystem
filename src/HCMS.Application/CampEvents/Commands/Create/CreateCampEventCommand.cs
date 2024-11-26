using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Commands.Create
{
    public class CreateCampEventCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Guid? CoachId { get; set; }
    }
    
}
