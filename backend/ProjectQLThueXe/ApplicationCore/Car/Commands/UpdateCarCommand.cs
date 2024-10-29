using MediatR;
using CarVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Car.Commands
{
    public class UpdateCarCommand : IRequest<CarVM::Car>
    {
        public Guid Car_ID { get; set; }
        public string Model { get; set; } = string.Empty;
        public string NumberPlate { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Location { get; set; } = string.Empty;
        public bool Status { get; set; }

        public int CarType_ID { get; set; }
        public Guid KCT_ID { get; set; }

    }
}
