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
    public class ReturnCarCommandHandler : IRequestHandler<ReturnCarCommand, Entity::Car>
    {
        private readonly ICarRepository _carRepository;
        public ReturnCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task<Entity::Car> Handle(ReturnCarCommand request, CancellationToken cancellationToken)
        {
            var result = await _carRepository.ReturnCarAsync(request.Car_ID, request.KT_ID);
            return result;
        }
    }
}
