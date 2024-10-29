using MediatR;
using  CarVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Car.Queries
{
    public class GetCarByIdQuery : IRequest<CarVM::Car>
    {
        public Guid Car_ID { get; set; }
    }
}
