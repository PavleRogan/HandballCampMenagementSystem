using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Commands.Delete
{
    internal class DeleteShiftCommandHandler : IRequestHandler<DeleteShiftCommand>
    {
        private IShiftsRepository _shiftsRepository;
        private IMapper _mapper;
        public DeleteShiftCommandHandler(IShiftsRepository shiftsRepository, IMapper mapper) { 
        
            _shiftsRepository = shiftsRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteShiftCommand request, CancellationToken cancellationToken)
        {
            var shift = await _shiftsRepository.GetByIdAsync(request.Id);
            if (shift == null)
            {
                throw new NotFoundException($"Shift with id: {request.Id} not found.");
            }

            await _shiftsRepository.DeleteAsync(shift);

        }
    }
}
