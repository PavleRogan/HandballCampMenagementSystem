using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class CampEvent
    {
        public Guid CampEventId { get; set; }

        [StringLength(100,MinimumLength =5)]
        public string Name { get; set; } = null!;

        [StringLength(150)]
        public string? Description { get; set; }

        public DateTime Start {  get; set; }

        public DateTime End { get; set; }

        public Guid? CoachId { get; set; }

        public Coach? Coach { get; set; }

        public List<Group> Groups { get; set; } = new List<Group>();
    }
}
