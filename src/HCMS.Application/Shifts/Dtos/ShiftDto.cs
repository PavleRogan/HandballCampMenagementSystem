using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Dtos
{
    public class ShiftDto
    {
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public int OrderNumber { get; set; }

        public int NumberOfPlayers { get; set; }

        public Guid SeasonId { get; set; }

        public Season Season { get; set; } = null!;
    }
}
