using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Admins.Commands.Update
{
    public class UpdateAdminCommand : IRequest
    {
        public Guid UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Surname { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public DateOnly DateOfBirth { get; set; }

        public string Gender { get; set; } = null!;

        public string HomeTown { get; set; } = null!;
    }
}
