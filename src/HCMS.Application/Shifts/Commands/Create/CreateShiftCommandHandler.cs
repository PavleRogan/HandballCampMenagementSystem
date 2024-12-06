using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Entities;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Commands.Create
{
    internal class CreateShiftCommandHandler(IShiftsRepository shiftsRepository,
        ISeasonsRepository seasonsRepository, ILogger<CreateShiftCommandHandler> logger) : IRequestHandler<CreateShiftCommand, Guid>
    {
        public async Task<Guid> Handle(CreateShiftCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Creating new shift: {@shift}", request);

            var season = await seasonsRepository.GetById(request.SeasonId);
            if (season == null)
            {
                throw new NotFoundException($"Season with id {request.SeasonId} not found");
            }
            var shift = new Shift
            {
                ShiftId = Guid.NewGuid(),
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                OrderNumber = request.OrderNumber,
                NumberOfPlayers = request.NumberOfPlayers,
                SeasonId = request.SeasonId
            };

            var createdId = await shiftsRepository.CreateAsync(shift);

            return createdId;
        }
    }
}
