using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Admins.Commands.Delete
{
    internal class DeleteAdminCommandHandler(IAdminsRepository adminsRepository) : IRequestHandler<DeleteAdminCommand>
    {
        public async Task Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {

            var admin = await adminsRepository.GetById(request.Id);

            if (admin == null)
            {
                throw new NotFoundException($"Admin with id {request.Id} not found.");
            }
            await adminsRepository.Delete(admin);

        }
    }
}
