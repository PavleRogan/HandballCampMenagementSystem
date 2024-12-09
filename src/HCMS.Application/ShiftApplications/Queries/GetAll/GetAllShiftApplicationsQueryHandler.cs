using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Seasons.Dtos;
using HCMS.Application.ShiftApplications.Dtos;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Queries.GetAll
{
    internal class GetAllShiftApplicationsQueryHandler(IShiftApplicationsRepository shiftApplicationsRepository,
        ILogger<GetAllShiftApplicationsQueryHandler> logger, IMapper mapper) : IRequestHandler<GetAllShiftApplicationsQuery, IEnumerable<ShiftApplicationDto>>
    {
        public async Task<IEnumerable<ShiftApplicationDto>> Handle(GetAllShiftApplicationsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Returning all applications.");
            var app = await shiftApplicationsRepository.GetAllAsync();
            var dtos = mapper.Map<IEnumerable<ShiftApplicationDto>>(app);
            return dtos;
        }
    }
}
