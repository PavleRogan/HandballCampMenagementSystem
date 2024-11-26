using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Commands.SubscribeGroupToEvent
{
    internal class SubscribeGroupToEventCommandHandler : IRequestHandler<SubscribeGroupToEventCommand>
    {
        private readonly ICampEventsRepository _eventRepository;
        private readonly IGroupsRepository _groupRepository;

        public SubscribeGroupToEventCommandHandler(
         ICampEventsRepository eventRepository,
            IGroupsRepository groupRepository)
        {
            _eventRepository = eventRepository;
            _groupRepository = groupRepository;
        }
        public async Task Handle(SubscribeGroupToEventCommand request, CancellationToken cancellationToken)
        {
            var eventEntity = await _eventRepository.GetById(request.EventId);
            if (eventEntity == null)
                throw new NotFoundException("Event not found.");

            var groupEntity = await _groupRepository.GetById(request.GroupId);
            if (groupEntity == null)
                throw new NotFoundException("Group not found.");

            if (!eventEntity.Groups.Contains(groupEntity))
            {
                eventEntity.Groups.Add(groupEntity);

                await _eventRepository.SaveChangesAsync();
            }

        }
    }
}
