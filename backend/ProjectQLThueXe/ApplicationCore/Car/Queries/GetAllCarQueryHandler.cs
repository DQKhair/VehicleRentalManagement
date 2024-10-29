using MediatR;
using ProjectQLThueXe.Domain.DTOs;
using CarVM = ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Car.Queries
{
    public class GetAllCarQueryHandler : IRequestHandler<GetAllCarQuery, IEnumerable<CarVM::Car>>
    {
        private readonly ICarRepository _carRepository;

        public GetAllCarQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<CarVM::Car>> Handle(GetAllCarQuery request, CancellationToken cancellationToken)
        {
            return await _carRepository.GetAllAsync();
        }
    }
}
