using AutoMapper;
using HCMS.Application.Admins.Dtos;
using HCMS.Application.Common.Interfaces;
using HCMS.Application.Players.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Admins.Queries.GetAll
{
    internal class GetAllAdminsQueryHandler(IAdminsRepository adminsRepository, IMapper mapper) : IRequestHandler<GetAllAdminsQuery, IEnumerable<AdminDto>>
    {
        public async Task<IEnumerable<AdminDto>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            var admins = await adminsRepository.GetAllAsync();
            var adminDtos = mapper.Map<IEnumerable<AdminDto>>(admins);
            return adminDtos;
        }
    }
}
