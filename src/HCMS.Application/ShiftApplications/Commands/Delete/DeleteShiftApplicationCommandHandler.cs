using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Commands.Delete
{
    internal class DeleteShiftApplicationCommandHandler(ILogger<DeleteShiftApplicationCommandHandler> logger, IShiftApplicationsRepository shiftApplicationsRepository) : IRequestHandler<DeleteShiftApplicationCommand>
    {
        public async Task Handle(DeleteShiftApplicationCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting applications with ShiftId: {ShiftId} and PlayerId: {PlayerId}", request.ShiftId, request.PlayerId);

            var application = await shiftApplicationsRepository.GetByIds(request.ShiftId,request.PlayerId);

            if (application == null)
            {
                throw new NotFoundException($"ShiftApplication with ids {request.ShiftId},{request.PlayerId} not found.");
            }
            await shiftApplicationsRepository.Delete(application);
        }
    }
    
}
