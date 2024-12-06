using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Shifts.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Queries.GetAll
{
    internal class GetAllShiftsQueryHandler(IShiftsRepository shiftsRepository, IMapper mapper, ILogger<GetAllShiftsQueryHandler> logger) : IRequestHandler<GetAllShiftsQuery, IEnumerable<ShiftDto>>
    {
        public async Task<IEnumerable<ShiftDto>> Handle(GetAllShiftsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting all shifts");

            var shifts = await shiftsRepository.GetAllAsync();

            var shiftDtos = mapper.Map<IEnumerable<ShiftDto>>(shifts);

            return shiftDtos;
        }
    }
}
