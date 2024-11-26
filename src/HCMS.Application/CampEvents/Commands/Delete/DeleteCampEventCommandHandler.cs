using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Commands.Delete
{
    internal class DeleteCampEventCommandHandler(ICampEventsRepository campEventsRepository) : IRequestHandler<DeleteCampEventCommand>
    {
        public async Task Handle(DeleteCampEventCommand request, CancellationToken cancellationToken)
        {
            var ev = await campEventsRepository.GetById(request.Id);

            if (ev == null)
            {
                throw new NotFoundException($"Event with id {request.Id} not found.");
            }
            await campEventsRepository.Delete(ev);
        }
    }
}
