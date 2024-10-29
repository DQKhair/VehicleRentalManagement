using MediatR;
using ProjectQLThueXe.Domain.Entities;
using CarTypeVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Queries
{
    public class GetCarTypeByIdQuery : IRequest<CarTypeVM::CarType> 
    {
        public int CarType_ID { get; set; }
    }
}
