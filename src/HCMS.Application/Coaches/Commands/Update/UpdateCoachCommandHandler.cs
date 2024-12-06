using AutoMapper;
using HCMS.Application.Admins.Commands.Update;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Entities;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Coaches.Commands.Update
{
    internal class UpdateCoachCommandHandler(ICoachesRepository coachesRepository, IMapper mapper) : IRequestHandler<UpdateCoachCommand>
    {
        public async Task Handle(UpdateCoachCommand request, CancellationToken cancellationToken)
        {

            var coach = await coachesRepository.GetById(request.UserId);
            if (coach == null)
            {
                throw new NotFoundException("Coach not found");
            }

            mapper.Map(request, coach);

            await coachesRepository.SaveChangesAsync();


        }
    }
}
