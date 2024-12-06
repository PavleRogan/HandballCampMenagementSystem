using HCMS.Application.Coaches.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Coaches.Queries.GetAll
{
    public class GetAllCoachesQuery : IRequest< IEnumerable<CoachDto>>
    {
    }
}
