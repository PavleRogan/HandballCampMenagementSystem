using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Entities;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Commands.Create
{
    internal class CreateCampEventCommandHandler(ICampEventsRepository campEventsRepository, ICoachesRepository coachesRepository) : IRequestHandler<CreateCampEventCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCampEventCommand request, CancellationToken cancellationToken)
        { 

            if (request.CoachId.HasValue)
            {
            
                var coach = await coachesRepository.GetById(request.CoachId.Value);

                if (coach == null)
                {
                    throw new NotFoundException("Coach not found");
                }

            }

            var campEvent = new CampEvent
            {
                CampEventId = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Start = request.Start,
                End = request.End,
                CoachId = request.CoachId
            };

            await campEventsRepository.Create(campEvent);
  

            return campEvent.CampEventId;
        }
    }
}
