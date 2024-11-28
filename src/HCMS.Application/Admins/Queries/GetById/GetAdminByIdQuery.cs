using HCMS.Application.Admins.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Admins.Queries.GetById
{
    public class GetAdminByIdQuery : IRequest<AdminDto>
    {
        public Guid Id { get; set; }
        public GetAdminByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
