using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Commands
{
    public class UpdateCarTypeCommandValidator : AbstractValidator<UpdateCarTypeCommand>
    {
        public UpdateCarTypeCommandValidator() 
        {
            RuleFor(x => x.CarTypeName).NotEmpty().WithMessage("Name is required.")
               .Length(1, 50).WithMessage("Name must be between 1 and 50 charactors");
        }
    }
}
