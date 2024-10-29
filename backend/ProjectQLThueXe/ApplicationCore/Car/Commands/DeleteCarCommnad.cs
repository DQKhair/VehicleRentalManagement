using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Car.Commands
{
    public class DeleteCarCommnad : IRequest<string>
    {
        public Guid Car_ID { get; set; }
    }
}
