using HCMS.Application.Common.Helpers;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Entities;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Register
{
    internal class RegisterCommandHandler(ILogger<RegisterCommandHandler> logger,
        IAuthHelper authHelper, IPasswordHasher passwordHasher, IPlayersRepository playersRepository) : IRequestHandler<RegisterCommand, Guid>
    {
        public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Registering new player");

            var userExists = await authHelper.UserWithEmailExists(request.Email);

            if (userExists)
            {
                throw new UserAlreadyExistsException("Email is already in use.");
            }

            var hashedPassword = passwordHasher.HashPassword(request.PasswordHash);

            var player = new Player
            {
                UserId = Guid.NewGuid(),
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PasswordHash = hashedPassword,
                PhoneNumber = request.PhoneNumber,
                DateOfBirth = request.DateOfBirth,
                Gender = request.Gender,
                HomeTown = request.HomeTown,
                Position = request.Position,
                TeamName = request.TeamName,
                EquipmentSize = request.EquipmentSize,
                ParentEmail = request.ParentEmail
            };

            await playersRepository.Create(player);

            return player.UserId;

        }
    }
}
