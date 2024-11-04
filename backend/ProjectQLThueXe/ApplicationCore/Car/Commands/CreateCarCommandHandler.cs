using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;
using ProjectQLThueXe.Domain.Models;

namespace ProjectQLThueXe.Application.Car.Commands
{
    class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Entity::Car>
    {
        private readonly ICarRepository _carRepository;
        public CreateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<Entity::Car> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var _postCarVM = new PostCarVM
            {
                Model = request.Model,
                NumberPlate = request.NumberPlate,
                Price = request.Price,
                Location = request.location,
                Status = request.status,
                CarType_ID = request.CarType_ID,
                KCT_ID = request.KCT_ID,
                Images = request.Image
            };
            return await _carRepository.AddAsync(_postCarVM); ;
        }
    }
}
