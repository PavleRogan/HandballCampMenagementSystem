using HCMS.Application.Groups.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Dtos
{
    public class CampEventDto
    {
        public Guid CampEventId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public Guid? CoachId { get; set; }

        public List<GroupDto> Groups { get; set; } = new List<GroupDto>();
    }
}
