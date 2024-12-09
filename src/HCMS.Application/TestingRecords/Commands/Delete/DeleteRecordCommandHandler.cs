using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.TestingRecords.Commands.Delete
{
    internal class DeleteRecordCommandHandler(ITestingRecordsRepository testingRecordsRepository, ILogger<DeleteRecordCommand> logger) : IRequestHandler<DeleteRecordCommand>
    {
        public async Task Handle(DeleteRecordCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting record wit id: {@shift}", request.Id);


            var record = await testingRecordsRepository.GetByIdAsync(request.Id);
            if (record == null)
            {
                throw new NotFoundException($"Record with id: {request.Id} not found.");
            }

            await testingRecordsRepository.DeleteAsync(record);
        }
    }
}
