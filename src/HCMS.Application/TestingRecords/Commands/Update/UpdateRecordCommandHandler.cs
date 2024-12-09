using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using AutoMapper;

namespace HCMS.Application.TestingRecords.Commands.Update
{
    internal class UpdateRecordCommandHandler(ILogger<UpdateRecordCommandHandler> logger, 
        ITestingRecordsRepository testingRecordsRepository, IMapper mapper) : IRequestHandler<UpdateRecordCommand>
    {
        public async Task Handle(UpdateRecordCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating testing record");

            var record = await testingRecordsRepository.GetByIdAsync(request.TestingRecordId);

            if (record == null)
            {
                throw new NotFoundException($"Record with id: {request.TestingRecordId} not found.");
            }

            mapper.Map(request, record);

            await testingRecordsRepository.SaveChangesAsync();
            
        }
    }
}
