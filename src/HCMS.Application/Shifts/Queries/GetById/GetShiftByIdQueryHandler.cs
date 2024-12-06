using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Shifts.Dtos;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Queries.GetById
{
    internal class GetShiftByIdQueryHandler(IShiftsRepository shiftsRepository, IMapper mapper, ILogger<GetShiftByIdQueryHandler> logger) : IRequestHandler<GetShiftByIdQuery, ShiftDto>
    {
        public async Task<ShiftDto> Handle(GetShiftByIdQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting shift wit id: {@shift}", request.Id);

            var shift = await shiftsRepository.GetByIdAsync(request.Id);
            if (shift == null)
            {
                throw new NotFoundException($"Shift with id: {request.Id} not found.");
            }
            else
            {
                var shiftDto = mapper.Map<ShiftDto>(shift);
                return shiftDto;
            }
        }
    }
}
