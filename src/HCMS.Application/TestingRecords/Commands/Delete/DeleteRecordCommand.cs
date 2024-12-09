using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.TestingRecords.Commands.Delete
{
    public class DeleteRecordCommand : IRequest
    {
        public Guid Id { get; set; }
        public DeleteRecordCommand(Guid id)
        {
            Id = id;
        }
    }
}
