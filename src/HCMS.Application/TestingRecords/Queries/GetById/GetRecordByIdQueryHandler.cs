using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Shifts.Dtos;
using HCMS.Application.TestingRecords.Dtos;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.TestingRecords.Queries.GetById
{
    internal class GetRecordByIdQueryHandler(ILogger<GetRecordByIdQueryHandler> logger,
        ITestingRecordsRepository testingRecordsRepository, IMapper mapper) : IRequestHandler<GetRecordByIdQuery, TestingRecordDto>
    {
        public async Task<TestingRecordDto> Handle(GetRecordByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting record wit id: {@shift}", request.Id);

            var r = await testingRecordsRepository.GetByIdAsync(request.Id);
            if (r == null)
            {
                throw new NotFoundException($"Record with id: {request.Id} not found.");
            }
            else
            {
                var dto = mapper.Map<TestingRecordDto>(r);
                return dto;
            }
        }
    }
}
