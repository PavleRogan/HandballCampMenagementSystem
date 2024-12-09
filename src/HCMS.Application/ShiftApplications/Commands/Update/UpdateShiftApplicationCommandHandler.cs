using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.ShiftApplications.Commands.Update
{
    internal class UpdateShiftApplicationCommandHandler(IShiftApplicationsRepository shiftApplicationsRepository) : IRequestHandler<UpdateShiftApplicationCommand>
    {
        public async Task Handle(UpdateShiftApplicationCommand request, CancellationToken cancellationToken)
        {
            var shiftApplication = await shiftApplicationsRepository.GetByIds(request.PlayerId, request.ShiftId);

            if (shiftApplication == null)
            {
                throw new NotFoundException("Shift application not found.");
            }

            shiftApplication.StatusOfApplication = request.StatusOfApplication;

            await shiftApplicationsRepository.SaveChangesAsync();

        }
    }
}
