using AutoMapper;
using HCMS.Application.Admins.Dtos;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Players.Dtos;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Admins.Queries.GetById
{
    internal class GetAdminByIdQueryHandler(IAdminsRepository adminsRepository, IMapper mapper) : IRequestHandler<GetAdminByIdQuery, AdminDto>
    {
        public async Task<AdminDto> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            var admin = await adminsRepository.GetById(request.Id);

            if (admin == null)
            {
                throw new NotFoundException($"Admin with id: {request.Id} not found.");

            }

            var adminDto = mapper.Map<AdminDto>(admin);

            return adminDto;
        }
    }
}
