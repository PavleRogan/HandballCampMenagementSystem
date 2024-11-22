using HCMS.Application.Seasons.Dtos;
using HCMS.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Queries.GetAllSeasons
{
    public class GetAllSeasonsQuery : IRequest<IEnumerable<SeasonDto>>
    {
    }
}
