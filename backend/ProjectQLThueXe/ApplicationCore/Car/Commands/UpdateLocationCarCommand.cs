using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Car.Commands
{
    public class UpdateLocationCarCommand : IRequest<Entity::Car>
    {
        public Guid Car_ID { get; set; }
        public string Location {  get; set; } = string.Empty;
    }
}
