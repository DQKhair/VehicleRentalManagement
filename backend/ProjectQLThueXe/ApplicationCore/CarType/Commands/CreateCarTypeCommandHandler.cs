using MediatR;
using CarTypeVM = ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Commands
{
    public class CreateCarTypeCommandHandler : IRequestHandler<CreateCarTypeCommand, string>
    {
        private readonly ICarTypeRepository _carTypeRepository;

        public CreateCarTypeCommandHandler(ICarTypeRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }

        public async Task<string> Handle(CreateCarTypeCommand request, CancellationToken cancellationToken)
        {
            var carType = new CarTypeVM::CarType { CarTypeName = request.CarTypeName};
            await _carTypeRepository.AddAsync(carType);
            return carType.CarTypeName;
        }
    }
}
