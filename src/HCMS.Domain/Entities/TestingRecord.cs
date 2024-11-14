using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class TestingRecord
    {
        public Guid TestingRecordId { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Weight { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Height { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal BodyFatPercentage { get; set; }

        public int SprintTime { get; set; }
        public int JumpHeightCm { get; set; }
        public int PushUpCount { get; set; }
        public DateTime MeasurementDate { get; set; }
        public string Notes { get; set; } = string.Empty;
        public Guid PlayerId { get; set; }

        public Player Player { get; set; } = null!;
    }
}
