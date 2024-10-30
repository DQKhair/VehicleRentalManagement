using FluentValidation;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Commands
{
    public class CreateCarTypeCommandValidator : AbstractValidator<CreateCarTypeCommand>
    {
        public CreateCarTypeCommandValidator()
        {
            RuleFor(x => x.CarTypeName).NotEmpty().WithMessage("Name is required.")
                .Length(1, 50).WithMessage("Name must be between 1 and 50 charactors");
        }
    }
}
