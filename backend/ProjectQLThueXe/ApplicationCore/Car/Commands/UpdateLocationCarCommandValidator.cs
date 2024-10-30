using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Car.Commands
{
    public class UpdateLocationCarCommandValidator : AbstractValidator<UpdateLocationCarCommand>
    {
        public UpdateLocationCarCommandValidator() 
        {
            RuleFor(e => e.Car_ID).NotEmpty().WithMessage("ID is required.");
            RuleFor(e => e.Location).NotEmpty().WithMessage("Location is required.")
                .MaximumLength(100);
        }
    }
}
