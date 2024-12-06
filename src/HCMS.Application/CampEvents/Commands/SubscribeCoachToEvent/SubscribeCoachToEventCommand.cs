using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Commands.SubscribeCoachToEvent
{
    public class SubscribeCoachToEventCommand : IRequest
    {
        public Guid EventId { get; set; }
        public Guid CoachId { get; set; }

        public SubscribeCoachToEventCommand(Guid eventId, Guid coachId)
        {
            EventId = eventId;
            CoachId = coachId;
        }
    }
}
