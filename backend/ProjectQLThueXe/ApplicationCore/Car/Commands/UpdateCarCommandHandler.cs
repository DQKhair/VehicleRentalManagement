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
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, CarVM::Car>
    {
        private readonly ICarRepository _carRepository;
        public UpdateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<CarVM.Car> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
           var _car = new CarVM.Car
           {
               Car_ID = request.Car_ID,
               Model = request.Model,
               Price = request.Price,
               location = request.Location,
               status = request.Status,
               CarType_ID = request.CarType_ID,
               KCT_ID = request.KCT_ID,
           };
            await _carRepository.UpdateAsync(_car.Car_ID, _car);
            return _car;
        }
    }
}
