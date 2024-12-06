using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Players.Commands.Update
{
    internal class UpdatePlayerCommandHandler(IPlayersRepository playersRepository, ILogger<UpdatePlayerCommandHandler> logger) : IRequestHandler<UpdatePlayerCommand>
    {

        public async Task Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Updating shift wit id: {@player}", request.UserId);

            var player = await playersRepository.GetById(request.UserId);
            if (player == null)
            {
                throw new NotFoundException($"Player with id: {request.UserId} not found.");

            }


            player.Position = request.Position;
            player.TeamName = request.TeamName;
            player.EquipmentSize = request.EquipmentSize;
            player.ParentEmail = request.ParentEmail;
            player.Name = request.Name;
            player.Surname = request.Surname;

            await playersRepository.SaveChangesAsync();
        }
    }
}
