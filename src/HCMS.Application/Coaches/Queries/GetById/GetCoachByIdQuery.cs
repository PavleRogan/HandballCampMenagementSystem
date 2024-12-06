using HCMS.Application.Coaches.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Coaches.Queries.GetById
{
    public class GetCoachByIdQuery : IRequest<CoachDto>
    {
        public Guid Id { get; set; }
        public GetCoachByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
