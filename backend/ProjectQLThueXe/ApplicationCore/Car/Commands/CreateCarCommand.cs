using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ProjectQLThueXe.Domain.Models;

namespace ProjectQLThueXe.Application.Car.Commands
{
    public class CreateCarCommand : IRequest<Entity::Car>
    {
        public Guid Car_ID { get; set; }
        public string Model { get; set; } = string.Empty;
        public string NumberPlate { get; set; } = string.Empty;
        public double Price { get; set; }
        public string location { get; set; } = string.Empty;
        public bool status { get; set; }
        public int CarType_ID { get; set; }
        public Guid KCT_ID { get; set; }
        public IFormFile Image { get; set; }

    }
}
