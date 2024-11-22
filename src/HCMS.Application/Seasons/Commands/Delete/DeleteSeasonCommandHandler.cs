using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Commands.Delete
{
    internal class DeleteSeasonCommandHandler(ISeasonsRepository seasonsRepository) : IRequestHandler<DeleteSeasonCommand>
    {
        public async Task Handle(DeleteSeasonCommand request, CancellationToken cancellationToken)
        {
            var season = await seasonsRepository.GetById(request.Id);

            if (season == null)
            {
                throw new NotFoundException($"Season with id {request.Id} not found.");
            }
            await seasonsRepository.Delete(season);
        }
    }
}
