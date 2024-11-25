using HCMS.Application.Shifts.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Queries.GetById
{
    public class GetShiftByIdQuery : IRequest<ShiftDto>
    {
        public Guid Id { get; set; }
        public GetShiftByIdQuery(Guid id) 
        {
            Id = id;
        }
    }
}
