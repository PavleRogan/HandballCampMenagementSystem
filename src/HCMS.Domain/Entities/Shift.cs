using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class Shift
    {
        public Guid ShiftId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int OrderNumber { get; set; }

        public int NumberOfPlayers { get; set; }
    }
}
