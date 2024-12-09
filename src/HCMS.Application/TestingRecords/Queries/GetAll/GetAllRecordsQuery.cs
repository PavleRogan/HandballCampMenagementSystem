using HCMS.Application.TestingRecords.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.TestingRecords.Queries.GetAll
{
    public class GetAllRecordsQuery : IRequest<IEnumerable<TestingRecordDto>>
    {
    }
}
