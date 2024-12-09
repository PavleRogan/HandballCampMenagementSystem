using HCMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Dtos
{
    public class ShiftApplicationDto
    {
        public Guid PlayerId { get; set; }
        public Guid ShiftId { get; set; }

        public Player Player { get; set; } = null!;

        public Shift Shift { get; set; } = null!;

        public DateOnly DateOfApply { get; set; }

        [StringLength(50)]
        public string StatusOfApplication { get; set; } = null!;
    }
}
