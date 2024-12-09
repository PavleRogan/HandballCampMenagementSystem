using HCMS.Application.TestingRecords.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.TestingRecords.Queries.GetByPlayerId
{
    public class GetRecordByPlayerIdQuery : IRequest<IEnumerable<TestingRecordDto>>
    {
        public Guid PlayerId { get; set; }
        public GetRecordByPlayerIdQuery(Guid playerId)
        {
            PlayerId = playerId;
        }
    }
}
