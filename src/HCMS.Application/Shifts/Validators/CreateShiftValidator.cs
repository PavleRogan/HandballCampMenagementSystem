using FluentValidation;
using HCMS.Application.Shifts.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCMS.Application.Shifts.Validators
{
    public class CreateShiftValidator : AbstractValidator<CreateShiftCommand>
    {
        public CreateShiftValidator() 
        {
            RuleFor(o => o.EndDate)
                .NotEmpty().LessThan(o => o.EndDate).WithMessage("Start date can not be after end date.");

            RuleFor(o => o.OrderNumber).NotEmpty().LessThan(5);

        }
    }
}
