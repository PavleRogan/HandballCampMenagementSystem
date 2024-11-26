using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Groups.Commands.Update
{
    internal class UpdateGroupCommandHandler(IGroupsRepository groupsRepository) : IRequestHandler<UpdateGroupCommand>
    {
        public async Task Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await groupsRepository.GetById(request.GroupId);
            if (group == null)
            {
                throw new NotFoundException($"Group with id: {request.GroupId} not found.");

            }


            group.Name = request.Name ?? group.Name;
            group.NumberOfMembers = request.NumberOfMembers;
            group.SeniorityLevel = request.SeniorityLevel;
            group.Position = request.Position ?? group.Position;
            group.Type = request.Type ?? group.Type;
            group.ShiftId = request.ShiftId;


            await groupsRepository.SaveChangesAsync();
        }
    }
}
