using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Commands.Delete
{
    public class DeleteSeasonCommand : IRequest
    {
        public Guid Id { get; set; }
        public DeleteSeasonCommand(Guid id) { 
            Id = id;
        }
    }
}
