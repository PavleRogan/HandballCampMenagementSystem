using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Entities;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Admins.Commands.Create
{
    internal class CreateAdminCommandHandler(IAdminsRepository adminsRepository, IPasswordHasher passwordHasher) : IRequestHandler<CreateAdminCommand, Guid>
    {
        public async Task<Guid> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            bool emailTaken = await adminsRepository.AdminWithEmailExists(request.Email);
            if (emailTaken)
            {
                throw new UserAlreadyExistsException("Email is already in use by another user.");
            }

            var admin = new Admin
            {
                UserId = Guid.NewGuid(),
                Email = request.Email,
                Name = request.Name,
                Surname = request.Surname,
                PhoneNumber = request.PhoneNumber,
                Gender = request.Gender,
                HomeTown = request.HomeTown,
                DateOfBirth = request.DateOfBirth,
                PasswordHash = passwordHasher.HashPassword(request.Password)
            };

            var id = await adminsRepository.Create(admin);

            return id;
        }
    }
}
 

