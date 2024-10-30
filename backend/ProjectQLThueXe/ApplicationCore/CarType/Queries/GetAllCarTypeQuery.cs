using MediatR;
using CarTypeVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Queries
{
    public class GetAllCarTypeQuery : IRequest<IEnumerable<CarTypeVM::CarType>>{}
}
