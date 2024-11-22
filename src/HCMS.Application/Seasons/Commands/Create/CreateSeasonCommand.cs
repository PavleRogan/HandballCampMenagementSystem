using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Seasons.Commands.Create
{
    public class CreateSeasonCommand : IRequest<Guid>
    {

        public string Name { get; set; } = null!;

        public int Year { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string LocationCity { get; set; } = null!;
    }
}
