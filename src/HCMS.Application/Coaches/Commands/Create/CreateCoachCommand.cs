using HCMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Coaches.Commands.Create
{
    public class CreateCoachCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string HomeTown { get; set; } = null!;
        public string? Biography { get; set; }

        public string TeamName { get; set; } = null!;

        public string EquipmentSize { get; set; } = null!;
    }
}
