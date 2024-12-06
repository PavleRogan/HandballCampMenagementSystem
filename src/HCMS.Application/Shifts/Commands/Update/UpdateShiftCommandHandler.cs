using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HCMS.Application.Shifts.Commands.Update
{
    internal class UpdateShiftCommandHandler(IShiftsRepository shiftsRepository, IMapper mapper, ILogger<UpdateShiftCommandHandler> logger) : IRequestHandler<UpdateShiftCommand>
    {
        public async Task Handle(UpdateShiftCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating shift wit id: {@shift}", request.ShiftId);

            var shift = await shiftsRepository.GetByIdAsync(request.ShiftId);
            if (shift == null)
            {
                throw new NotFoundException($"Shift with id: {request.ShiftId} not found.");
            }

            mapper.Map(request, shift);

            await shiftsRepository.SaveChangesAsync();
        }
    }
}
