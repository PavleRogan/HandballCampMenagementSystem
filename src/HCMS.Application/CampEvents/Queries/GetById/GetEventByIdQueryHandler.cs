using AutoMapper;
using HCMS.Application.CampEvents.Dtos;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.CampEvents.Queries.GetById
{
    internal class GetEventByIdQueryHandler : IRequestHandler<GetEventByIdQuery, CampEventDto>
    {
        private readonly ICampEventsRepository _campEventRepository;
        private readonly IMapper _mapper;

        public GetEventByIdQueryHandler(ICampEventsRepository campEventRepository, IMapper mapper)
        {
            _campEventRepository = campEventRepository;
            _mapper = mapper;
        }

        public async Task<CampEventDto> Handle(GetEventByIdQuery request, CancellationToken cancellationToken)
        {
            var campEvent = await _campEventRepository.GetById(request.CampEventId);

            if (campEvent == null)
            {
                throw new NotFoundException("Event not found");
            }

            var campEventDto = _mapper.Map<CampEventDto>(campEvent);

            return campEventDto;
        }
    }
}

