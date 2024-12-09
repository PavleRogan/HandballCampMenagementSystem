using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.ShiftApplications.Dtos;
using HCMS.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Commands.Create
{
    internal class CreateShiftApplicationCommandHandler(ILogger<CreateShiftApplicationCommandHandler> logger, 
        IShiftApplicationsRepository applicationsRepository, IMapper mapper) : IRequestHandler<CreateShiftApplicationCommand, ShiftApplicationDto>
    {
        public async Task<ShiftApplicationDto> Handle(CreateShiftApplicationCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new shift application");

            var shiftApplication = new ShiftApplication
            {
                PlayerId = request.PlayerId,
                ShiftId = request.ShiftId
            };

            await applicationsRepository.Create(shiftApplication);

            var dto = mapper.Map<ShiftApplicationDto>(shiftApplication);

            return dto;
        }
    }
}
