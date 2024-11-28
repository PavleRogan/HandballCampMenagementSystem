using HCMS.Application.Players.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Players.Queries.GetAll
{
    public class GetAllPlayersQuery : IRequest<IEnumerable<PlayerDto>>
    {
    }
}
