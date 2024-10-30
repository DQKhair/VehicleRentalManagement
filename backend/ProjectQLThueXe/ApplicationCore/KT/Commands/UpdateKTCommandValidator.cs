using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KT.Commands
{
    public class UpdateKTCommandValidator : AbstractValidator<UpdateKTCommand>
    {
        public UpdateKTCommandValidator() 
        {
            RuleFor(x => x.KT_Name).NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name maximun 50 charactors");
            RuleFor(x => x.KT_Phone).NotEmpty().WithMessage("Phone is required.")
                .MaximumLength(12).WithMessage("Phone invalid");
            RuleFor(x => x.KT_Address).MaximumLength(100).WithMessage("Address maximum 100 charactors");
            RuleFor(x => x.KT_CCCD).MaximumLength(12).WithMessage("CCCD invalid");
        }
    }
}
