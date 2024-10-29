using MediatR;
using CarVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.Car.Queries
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarVM::Car>
    {
        private readonly ICarRepository _carRepository;
        public GetCarByIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarVM.Car> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            return await _carRepository.GetByIdAsync(request.Car_ID);
        }
    }
}
