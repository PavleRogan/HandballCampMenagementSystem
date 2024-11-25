using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Shifts.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Queries.GetAll
{
    internal class GetAllShiftsQueryHandler(IShiftsRepository shiftsRepository, IMapper mapper) : IRequestHandler<GetAllShiftsQuery, IEnumerable<ShiftDto>>
    {
        public async Task<IEnumerable<ShiftDto>> Handle(GetAllShiftsQuery request, CancellationToken cancellationToken)
        {
            var shifts = await shiftsRepository.GetAllAsync();

            var shiftDtos = mapper.Map<IEnumerable<ShiftDto>>(shifts);

            return shiftDtos;
        }
    }
}
