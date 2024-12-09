using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.TestingRecords.Dtos;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.TestingRecords.Queries.GetByPlayerId
{
    internal class GetRecordByPlayerIdQueryHandler(ILogger<GetRecordByPlayerIdQueryHandler> logger,
        ITestingRecordsRepository testingRecordsRepository, IMapper mapper) : IRequestHandler<GetRecordByPlayerIdQuery, IEnumerable<TestingRecordDto>>
    {
        public async Task<IEnumerable<TestingRecordDto>> Handle(GetRecordByPlayerIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting records for player with id: {@recod}", request.PlayerId);

            var r = await testingRecordsRepository.GetByPlayerIdAsync(request.PlayerId);
           
            
            var dtos = mapper.Map<IEnumerable<TestingRecordDto>>(r);
            return dtos;
            
        }
    }
}
