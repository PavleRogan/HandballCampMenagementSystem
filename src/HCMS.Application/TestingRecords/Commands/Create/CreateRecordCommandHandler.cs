using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.TestingRecords.Commands.Create
{
    internal class CreateRecordCommandHandler(ITestingRecordsRepository testingRecordsRepository, ILogger<CreateRecordCommandHandler> logger) : IRequestHandler<CreateRecordCommand, Guid>
    {
        public async Task<Guid> Handle(CreateRecordCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new Testing Record");

            var record = new TestingRecord
            {
                TestingRecordId = Guid.NewGuid(),
                Weight = request.Weight,
                Height = request.Height,
                BodyFatPercentage = request.BodyFatPercentage,
                SprintTime = request.SprintTime,
                JumpHeightCm = request.JumpHeightCm,
                PushUpCount = request.PushUpCount,
                MeasurementDate = request.MeasurementDate,
                Notes = request.Notes,
                PlayerId = request.PlayerId
            };

            await testingRecordsRepository.CreateAsync(record);

            return record.TestingRecordId; 
        }
    }
}
