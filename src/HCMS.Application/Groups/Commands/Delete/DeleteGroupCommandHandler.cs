using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Groups.Commands.Delete
{
    internal class DeleteGroupCommandHandler(IGroupsRepository groupsRepository) : IRequestHandler<DeleteGroupCommand>
    {
        public async Task Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {

            var g = await groupsRepository.GetById(request.Id);

            if (g == null)
            {
                throw new NotFoundException($"Group with id {request.Id} not found.");
            }
            await groupsRepository.Delete(g);
        }
    }
}
