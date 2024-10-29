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
    public class UpdateCarTypeCommandHandler : IRequestHandler<UpdateCarTypeCommand, string>
    {
        private readonly ICarTypeRepository _carTypeRepository;
        public UpdateCarTypeCommandHandler(ICarTypeRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }
        public async Task<string> Handle(UpdateCarTypeCommand request, CancellationToken cancellationToken)
        {
          var _carType = new CarTypeVM::CarType { CarType_ID = request.CarType_ID, CarTypeName = request.CarTypeName};
            await _carTypeRepository.UpdateAsync(_carType.CarType_ID, _carType);
            return _carType.CarTypeName;
        }
    }
}
