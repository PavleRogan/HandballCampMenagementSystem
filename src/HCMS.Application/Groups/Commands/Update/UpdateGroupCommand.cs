using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Groups.Commands.Update
{
    public class UpdateGroupCommand : IRequest
    {
        public Guid GroupId { get; set; }

        public string Name { get; set; } = null!;

        public int NumberOfMembers { get; set; }

        public int SeniorityLevel { get; set; }

        public string Position { get; set; } = null!;

        public string Type { get; set; } = null!;

        public Guid ShiftId { get; set; }
    }
}
