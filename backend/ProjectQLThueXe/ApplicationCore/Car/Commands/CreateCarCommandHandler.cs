using MediatR;
using CarVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.Car.Commands
{
    class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CarVM::Car>
    {
        private readonly ICarRepository _carRepository;
        public CreateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<CarVM::Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var _car = new CarVM::Car
            {
                Car_ID = Guid.NewGuid(),
                Model = request.Model,
                NumberPlate = request.NumberPlate,
                Price = request.Price,
                location = request.location,
                status = request.status,
                CarType_ID = request.CarType_ID,
                KCT_ID = request.KCT_ID,
            };
            await _carRepository.AddAsync(_car);
            return _car;
        }
    }
}
