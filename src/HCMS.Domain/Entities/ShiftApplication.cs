using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class ShiftApplication
    {
        public Guid PlayerId { get; set; }
        public Guid ShiftId { get; set; }

        public Player Player { get; set; } = null!;

        public Shift Shift { get; set; } = null!;

        public DateOnly DateOfApply { get; set; }

        public string StatusOfApplication { get; set; } = "Pending";
    }
}
