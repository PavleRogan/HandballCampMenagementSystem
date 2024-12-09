using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Shifts.Dtos;
using HCMS.Application.TestingRecords.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.TestingRecords.Queries.GetAll
{
    internal class GetAllRecordsQueryHandler(ILogger<GetAllRecordsQueryHandler> logger,
       ITestingRecordsRepository testingRecordsRepository, IMapper mapper) : IRequestHandler<GetAllRecordsQuery, IEnumerable<TestingRecordDto>>
    {
        public async Task<IEnumerable<TestingRecordDto>> Handle(GetAllRecordsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all records");

            var records = await testingRecordsRepository.GetAllAsync();

            var dtos = mapper.Map<IEnumerable<TestingRecordDto>>(records);

            return dtos;
        }
    }
}
