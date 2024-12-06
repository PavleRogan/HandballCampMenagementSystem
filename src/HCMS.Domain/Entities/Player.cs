using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class Player : User
    {
        [StringLength(20)]
        public string? Position { get; set; }

        [StringLength(50)]
        public string? TeamName { get; set; }

        [StringLength(5)]
        public string? EquipmentSize { get; set;}

        [EmailAddress(ErrorMessage ="Enter valid email adress")]
        public string? ParentEmail { get; set; }

        public List<ShiftApplication> ShiftApplications { get; set; } = new List<ShiftApplication>();

        public List<Group> Groups { get; set; } = new List<Group>();

        public List<TestingRecord> TestingRecords { get; set; } = new List<TestingRecord>();
        
    }
}
