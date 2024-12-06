using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Commands.SubscribeCoachToEvent
{
    internal class SubscribeCoachToEventCommandHandler(ICoachesRepository coachesRepository, ICampEventsRepository campEventsRepository) : IRequestHandler<SubscribeCoachToEventCommand>
    {
        public async Task Handle(SubscribeCoachToEventCommand request, CancellationToken cancellationToken)
        {
            var coach = await coachesRepository.GetById(request.CoachId);
            var eventEntity = await campEventsRepository.GetById(request.EventId);

            if (coach == null)
            {
                throw new NotFoundException($"Coach with ID {request.CoachId} not found.");
            }

            if (eventEntity == null)
            {
                throw new NotFoundException($"Event with ID {request.EventId} not found.");
            }

            eventEntity.Coach = coach;

           
            await campEventsRepository.SaveChangesAsync();

        }
    }
}
