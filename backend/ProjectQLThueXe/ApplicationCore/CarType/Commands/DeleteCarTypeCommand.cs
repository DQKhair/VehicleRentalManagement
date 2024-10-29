using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Commands
{
    public class DeleteCarTypeCommand : IRequest<string>
    {
        public int CarType_ID { get; set; }
    }
}
