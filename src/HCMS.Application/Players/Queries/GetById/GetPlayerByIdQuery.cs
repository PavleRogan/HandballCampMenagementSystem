using HCMS.Application.Players.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Players.Queries.GetAll
{
    public class GetPlayerByIdQuery : IRequest<PlayerDto>
    {
        public Guid Id { get; set; }
        public GetPlayerByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
