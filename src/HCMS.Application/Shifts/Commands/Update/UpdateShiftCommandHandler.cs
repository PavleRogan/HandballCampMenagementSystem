using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HCMS.Application.Shifts.Commands.Update
{
    internal class UpdateShiftCommandHandler(IShiftsRepository shiftsRepository, IMapper mapper) : IRequestHandler<UpdateShiftCommand>
    {
        public async Task Handle(UpdateShiftCommand request, CancellationToken cancellationToken)
        {
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
