using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Groups.Commands.Delete
{
    public class DeleteGroupCommand :IRequest
    {
        public Guid Id { get; set; }
        public DeleteGroupCommand(Guid id)
        {
            Id = id;
        }
    }
}
