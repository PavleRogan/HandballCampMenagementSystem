using HCMS.Application.Admins.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Admins.Queries.GetAll
{
    public class GetAllAdminsQuery : IRequest<IEnumerable<AdminDto>>
    {
    }
}
