using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.Car.Queries
{
    public class GetCarByNumberPlateQueryHandler : IRequestHandler<GetCarByNumberPlateQuery, Entity::Car>
    {
        private readonly ICarRepository _carRepository;
        public GetCarByNumberPlateQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Entity::Car> Handle(GetCarByNumberPlateQuery request, CancellationToken cancellationToken)
        {
            return await _carRepository.GetByNumberPlate(request.NumberPlate);
        }
    }
}
