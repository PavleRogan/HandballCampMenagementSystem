using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Commands.Create
{
    public class CreateShiftCommand : IRequest<Guid>
    {
        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public int OrderNumber { get; set; }

        public int NumberOfPlayers { get; set; }

        public Guid SeasonId { get; set; }
    }
}
