using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Seasons.Dtos;
using HCMS.Application.ShiftApplications.Dtos;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Queries.GetById
{
    internal class GetShiftApplicationByIdsQueryHandler(ILogger<GetShiftApplicationByIdsQueryHandler> logger,
        IShiftApplicationsRepository shiftApplicationsRepository, IMapper mapper) : IRequestHandler<GetShiftApplicationByIdsQuery, ShiftApplicationDto>
    {
        public async Task<ShiftApplicationDto> Handle(GetShiftApplicationByIdsQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Getting applications with ShiftId: {ShiftId} and PlayerId: {PlayerId}", request.ShiftId, request.PlayerId);

            var app = await shiftApplicationsRepository.GetByIds(request.ShiftId,request.PlayerId);

            if (app == null)
            {
                throw new NotFoundException($"Application with id: {request.ShiftId},{request.PlayerId} not found.");

            }

            var dto = mapper.Map<ShiftApplicationDto>(app);

            return dto;
        }
    }

}
