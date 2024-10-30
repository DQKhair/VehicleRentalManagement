using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Queries
{
    public class GetCarTypeByNameQuery : IRequest<Entity::CarType>
    {
        public string CarTypeName { get; set; } = string.Empty;
    }
}
