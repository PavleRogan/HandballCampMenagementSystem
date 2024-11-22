using HCMS.Application.Seasons.Dtos;
using HCMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Queries.GetSeasonById
{
    public class GetSeasonByIdQuery : IRequest<SeasonDto>
    {
        public  Guid Id { get; set; }
        public GetSeasonByIdQuery(Guid id) {
             Id = id;
        }
    }
}
