using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Admins.Commands.Update
{
    internal class UpdateAdminCommandHandler(IAdminsRepository _adminsRepository) : IRequestHandler<UpdateAdminCommand>
    {
        public async Task Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _adminsRepository.GetById(request.UserId);
            if (admin == null)
            {
                throw new NotFoundException("Admin not found");
            }

            admin.Name = request.Name;
            admin.Surname = request.Surname;
            admin.PhoneNumber = request.PhoneNumber;
            admin.DateOfBirth = request.DateOfBirth;
            admin.Gender = request.Gender;
            admin.HomeTown = request.HomeTown;

            await _adminsRepository.SaveChangesAsync();

        }
    }
}

