using AutoMapper;
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
        private readonly ICoachesRepository _coachRepository;
        private readonly IMapper _mapper;

        public UpdateCampEventCommandHandler(
            ICampEventsRepository eventRepository,
            ICoachesRepository coachRepository,
            IMapper mapper
            )
        {
            _eventRepository = eventRepository;
            _coachRepository = coachRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCampEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _eventRepository.GetById(request.CampEventId);
            if (eventEntity == null)
                throw new NotFoundException("Event not found.");

            if (request.CoachId.HasValue)
            {
                var coach = await _coachRepository.GetById(request.CoachId.Value);
                if (coach == null)
                    throw new Exception("Coach with the specified ID does not exist.");
            }

            _mapper.Map(request, eventEntity);

            await _eventRepository.SaveChangesAsync();

        }
    }
}

