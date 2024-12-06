using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class Season
    {
        public Guid SeasonId { get; set; }


        [StringLength(50)]
        public string Name { get; set; } = null!;

        public int Year { get; set; } 

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set;}

        [StringLength(50)]
        public string LocationCity { get; set; } = null!;

        public List<Shift> Shifts { get; set; } = new List<Shift>();

    }
}
