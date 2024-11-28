using HCMS.Application.Groups.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Players.Dtos
{
    public class PlayerDto
    {
        public Guid UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateOnly DateOfBirdth { get; set; }

        public string Gender { get; set; } = null!;

        public string HomeTown { get; set; } = null!;
        public string? Position { get; set; }

        public string? TeamName { get; set; }

        public string? EquipmentSize { get; set; }

        public string? ParentEmail { get; set; }
        public List<GroupDto> Groups { get; set; } = new List<GroupDto>();

    }
}
