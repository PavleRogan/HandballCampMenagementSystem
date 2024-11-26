using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Commands.Update
{
    internal class UpdateCampEventCommandHandler : IRequestHandler<UpdateCampEventCommand>
    {
        private readonly ICampEventsRepository _eventRepository;
        //private readonly ICoachRepository _coachRepository;

        public UpdateCampEventCommandHandler(
            ICampEventsRepository eventRepository
           // ICoachRepository coachRepository
            )
        {
            _eventRepository = eventRepository;
            //_coachRepository = coachRepository;
        }

        public async Task Handle(UpdateCampEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _eventRepository.GetById(request.CampEventId);
            if (eventEntity == null)
                throw new NotFoundException("Event not found.");

            if (request.CoachId.HasValue)
            {
              //  var coachExists = await _coachRepository.ExistsAsync(request.CoachId.Value);
              //  if (!coachExists)
               //     throw new Exception("Coach with the specified ID does not exist.");
            }

            eventEntity.Name = request.Name;
            eventEntity.Description = request.Description;
            eventEntity.Start = request.Start;
            eventEntity.End = request.End;
            eventEntity.CoachId = request.CoachId;

            await _eventRepository.SaveChangesAsync();

        }
    }
}

