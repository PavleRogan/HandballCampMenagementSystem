using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Players.Commands.Update
{
    public class UpdatePlayerCommand : IRequest
    {
        public Guid UserId { get; set; }

        public string? Position { get; set; }

        public string? TeamName { get; set; }

        public string? EquipmentSize { get; set; }

        public string? ParentEmail { get; set; }
        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;
    }
}
