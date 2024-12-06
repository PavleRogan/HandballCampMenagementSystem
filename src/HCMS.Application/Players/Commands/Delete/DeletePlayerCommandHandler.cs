using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Players.Commands.Delete
{
    internal class DeletePlayerCommandHandler(IPlayersRepository playersRepository, ILogger<DeletePlayerCommandHandler> logger) : IRequestHandler<DeletePlayerCommand>
    {
        public async Task Handle(DeletePlayerCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting player wit id: {@player}", request.Id);

            var player = await playersRepository.GetById(request.Id);

            if (player == null)
            {
                throw new NotFoundException("Player not found");
            }

            await playersRepository.Delete(player);
        }
    }
}
