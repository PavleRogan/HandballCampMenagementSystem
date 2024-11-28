using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Players.Commands.Delete
{
    public class DeletePlayerCommand : IRequest
    {
        public Guid Id { get; set; }
        public DeletePlayerCommand(Guid id)
        {
            Id = id;
        }
    }
}
