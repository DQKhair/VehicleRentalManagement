using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Receipt.Commands
{
    public class CreateReceiptCommandValidator : AbstractValidator<CreateReceiptCommand>
    {
        public CreateReceiptCommandValidator() 
        {
            RuleFor(x => x.KT_ID).NotEmpty().WithMessage("ID is required.");
            RuleFor(x => x.ReceiptDescription).MaximumLength(100).WithMessage("Description can't be more than 100 characters.");
        }
    }
}
