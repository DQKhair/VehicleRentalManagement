using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Car.Commands
{
    public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator() 
        {
            RuleFor(e => e.Model).NotEmpty().WithMessage("Model is required.")
                .MaximumLength(50);

            RuleFor(e => e.Price).NotEmpty().WithMessage("Price is required.")
                .InclusiveBetween(1, 100000000).WithMessage("Price must be between 1 and 100,000,000.");

        }
    }
}
