using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KCT.Commands
{
    public class UpdateKCTCommandValidator : AbstractValidator<UpdateKCTCommand>
    {
        public UpdateKCTCommandValidator() 
        {
            RuleFor(x => x.KCT_Name).NotEmpty().WithMessage("Name is required.")
               .Length(1, 50).WithMessage("Name maximum 50 charactors");
            RuleFor(x => x.KCT_Phone).NotEmpty().WithMessage("Phone is required")
                .Length(11, 12).WithMessage("Invalid.");
            RuleFor(x => x.KCT_Address).MaximumLength(100).WithMessage("Address maximum 100 charactor");
            RuleFor(x => x.KCT_CCCD).NotEmpty().WithMessage("CCCD is required.");
        }
    }
}
