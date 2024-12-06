using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Entities;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Coaches.Commands.Create
{
    internal class CreateCoachCommandHandler(ICoachesRepository coachesRepository, IPasswordHasher passwordHasher) : IRequestHandler<CreateCoachCommand, Guid>
    {
        public async Task<Guid> Handle(CreateCoachCommand request, CancellationToken cancellationToken)
        {
            bool emailTaken = await coachesRepository.UserWithEmailExists(request.Email);
            if (emailTaken)
            {
                throw new UserAlreadyExistsException("Email is already in use by another user.");
            }

            var coach = new Coach
            {

                UserId = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PasswordHash = passwordHasher.HashPassword(request.Password), 
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                HomeTown = request.HomeTown,
                Biography = request.Biography,
                TeamName = request.TeamName,
                EquipmentSize = request.EquipmentSize,
            };

            var id = await coachesRepository.Create(coach);

            return id;
        }
    }
}
