using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class Event
    {
        public Guid EventId { get; set; }

        public string Name { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime Start {  get; set; }

        public DateTime End { get; set; }

        public Guid CoachId { get; set; }
    }
}
