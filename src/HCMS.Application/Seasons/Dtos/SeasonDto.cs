using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Dtos
{
    public class SeasonDto
    {
        public string Name { get; set; } = null!;

        public int Year { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string LocationCity { get; set; } = null!;

        public List<Shift?>? Shifts { get; set; } 
    }
}
