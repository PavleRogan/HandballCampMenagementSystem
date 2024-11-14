using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class Group
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; } = null!;

        public int NumberOfMembers { get; set; }

        public int SeniorityLevel { get; set; } 

        public string Position { get; set; } = null!;

        public string Type { get; set; } = null!;

        public Guid ShiftId { get; set; }

        public Shift Shift { get; set; } = null!;

        public List<Player> Player { get; set; } = new List<Player>();

        public List<Event> Events { get; set; } = new List<Event>();
    }
}
