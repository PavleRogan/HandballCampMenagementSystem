using HCMS.Application.Shifts.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Queries.GetAll
{
    public class GetAllShiftsQuery : IRequest<IEnumerable<ShiftDto>>
    { 

    }
}
