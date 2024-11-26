using HCMS.Application.Common.Interfaces;
using HCMS.Application.Seasons.Commands.Create;
using HCMS.Domain.Entities;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Groups.Commands.Create
{
    internal class CreateGroupCommandHandler(IGroupsRepository groupsRepository, IShiftsRepository shiftsRepository) : IRequestHandler<CreateGroupCommand, Guid>
    {
        public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var shift = await shiftsRepository.GetByIdAsync(request.ShiftId);
            if (shift == null)
            {
                throw new NotFoundException($"Shift with id {request.ShiftId} not found");
            }

            var group = new Group
            {
                GroupId = Guid.NewGuid(),
                Name = request.Name,
                NumberOfMembers = request.NumberOfMembers,
                SeniorityLevel = request.SeniorityLevel,
                Position = request.Position,
                Type = request.Type,
                ShiftId = request.ShiftId,
                Shift = shift

            };
            await groupsRepository.Create(group);

            return group.ShiftId;

        }   
    }
}
