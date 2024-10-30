using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.Car.Commands
{
    public class UpdateLocationCarCommandHandler : IRequestHandler<UpdateLocationCarCommand, Entity::Car>
    {
        private readonly ICarRepository _carRepository;
        public UpdateLocationCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Entity::Car> Handle(UpdateLocationCarCommand request, CancellationToken cancellationToken)
        {
            var _updated = await _carRepository.UpdateLocationAsync(request.Car_ID,request.Location);
            return _updated;
        }
    }
}
