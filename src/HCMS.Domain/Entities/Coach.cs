using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class Coach : User
    {
        [StringLength(150)]
        public string? Biography { get; set; }

        [StringLength(50)]
        public string? TeamName { get; set; }

        [StringLength(5)]
        public string? EquipmentSize { get; set; }

        public List<CampEvent> CampEvents { get; set; } = new List<CampEvent>();

    }
}
