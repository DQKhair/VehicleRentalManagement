using MediatR;
using CarVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Car.Commands
{
    public class CreateCarCommand : IRequest<CarVM::Car>
    {
        public Guid Car_ID { get; set; }
        public string Model { get; set; } = string.Empty;
        public double Price { get; set; }
        public string location { get; set; } = string.Empty;
        public bool status { get; set; }
        public int CarType_ID { get; set; }
        public Guid KCT_ID { get; set; }

    }
}
