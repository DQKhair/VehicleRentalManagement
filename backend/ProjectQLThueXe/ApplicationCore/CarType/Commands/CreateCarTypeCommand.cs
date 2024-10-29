using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Commands
{
    public class CreateCarTypeCommand : IRequest<string>
    {
        public string CarTypeName { get; set; } = string.Empty;
    }
}
