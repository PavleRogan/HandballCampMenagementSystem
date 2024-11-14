using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Domain.Entities
{
    public class Player : User
    {
        public string? Position { get; set; } 

        public string? TeamName { get; set; }

        public string? EquipmentSize { get; set;}

        public string? ParentEmail { get; set; }

        public List<Application> Applications { get; set; } = new List<Application>();

        public List<Group> Groups { get; set; } = new List<Group>();

        public List<TestingRecord> TestingRecords { get; set; } = new List<TestingRecord>();
        
    }
}
