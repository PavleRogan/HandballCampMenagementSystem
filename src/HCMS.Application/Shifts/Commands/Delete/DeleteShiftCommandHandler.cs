using AutoMapper;
using HCMS.Application.Common.Interfaces;
using HCMS.Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
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
        private ILogger<DeleteShiftCommandHandler> _logger; 
        public DeleteShiftCommandHandler(IShiftsRepository shiftsRepository, IMapper mapper, ILogger<DeleteShiftCommandHandler> logger) { 
        
            _shiftsRepository =shiftsRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task Handle(DeleteShiftCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Deleting shift wit id: {@shift}", request.Id);


            var shift = await _shiftsRepository.GetByIdAsync(request.Id);
            if (shift == null)
            {
                throw new NotFoundException($"Shift with id: {request.Id} not found.");
            }

            await _shiftsRepository.DeleteAsync(shift);

        }
    }
}
