using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Coaches.Commands.Delete
{
    internal class DeleteCoachCommandHandler(ICoachesRepository coachesRepository) : IRequestHandler<DeleteCoachCommand>
    {
        public async Task Handle(DeleteCoachCommand request, CancellationToken cancellationToken)
        {
            var coach = await coachesRepository.GetById(request.Id);

            if (coach == null)
            {
                throw new NotFoundException($"Coach with id {request.Id} not found.");
            }
            await coachesRepository.Delete(coach);
        }
    }
}
