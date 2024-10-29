using FluentValidation;
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
            RuleFor(x => x.CarTypeName).NotEmpty().WithMessage("Name is required.").Length(1,50);
        }
    }
}
