using MediatR;
using ProjectQLThueXe.Domain.DTOs;
using CarVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Car.Queries
{
    public class GetAllCarQuery : IRequest<IEnumerable<CarVM::Car>> { }
}
