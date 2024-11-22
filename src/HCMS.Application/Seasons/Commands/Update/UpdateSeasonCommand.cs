using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Commands.Update
{
    public class UpdateSeasonCommand : IRequest
    {
        public Guid SeasonId { get; set; }

        public string Name { get; set; } = null!;

        public int Year { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string LocationCity { get; set; } = null!;
    }
}
