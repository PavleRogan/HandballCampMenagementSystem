using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Commands.Delete
{
    internal class DeleteSeasonCommandHandler(ISeasonsRepository seasonsRepository, ILogger<DeleteSeasonCommandHandler> logger) : IRequestHandler<DeleteSeasonCommand>
    {
        public async Task Handle(DeleteSeasonCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting season wit id: {@shift}", request.Id);

            var season = await seasonsRepository.GetById(request.Id);

            if (season == null)
            {
                throw new NotFoundException($"Season with id {request.Id} not found.");
            }
            await seasonsRepository.Delete(season);
        }
    }
}
