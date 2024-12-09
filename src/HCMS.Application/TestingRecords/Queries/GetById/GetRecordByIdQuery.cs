using HCMS.Application.TestingRecords.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.TestingRecords.Queries.GetById
{
    public class GetRecordByIdQuery : IRequest<TestingRecordDto>
    {
        public Guid Id { get; set; }
        public GetRecordByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
