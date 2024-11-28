using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Admins.Commands.Delete
{
    public class DeleteAdminCommand : IRequest
    {
        public Guid Id { get; set; }
        public DeleteAdminCommand(Guid id)
        {
            Id = id;
        }
    }
}
