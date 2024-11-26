using AutoMapper;
using HCMS.Application.CampEvents.Dtos;
using HCMS.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Queries.GetAll
{
    internal class GetAllEventsQueryHandler : IRequestHandler<GetAllEventsQuery, IEnumerable<CampEventDto>>
    {
        private readonly ICampEventsRepository _campEventRepository;
        private readonly IMapper _mapper;

        public GetAllEventsQueryHandler(ICampEventsRepository campEventRepository, IMapper mapper)
        {
            _campEventRepository = campEventRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CampEventDto>> Handle(GetAllEventsQuery request, CancellationToken cancellationToken)
        {
            var campEvents = await _campEventRepository.GetAllAsync();

            var campEventDtos = _mapper.Map<IEnumerable<CampEventDto>>(campEvents);

            return campEventDtos;
        }
    }
}
