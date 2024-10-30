using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Car.Queries
{
    public class GetCarByNumberPlateQuery : IRequest<Entity::Car>
    {
        public string NumberPlate { get; set; } = string.Empty;
    }
}
