using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Commands.SubscribeGroupToEvent
{
    public class SubscribeGroupToEventCommand : IRequest
    {
        public Guid EventId { get; set; }
        public Guid GroupId { get; set; }

        public SubscribeGroupToEventCommand(Guid eventId, Guid groupId)
        {
            EventId = eventId;
            GroupId = groupId;
        }
    }
}
