using MediatR;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Commands
{
    internal class DeleteCarTypeCommandHandler : IRequestHandler<DeleteCarTypeCommand, string>
    {
        private readonly ICarTypeRepository _carTypeRepository;

        public DeleteCarTypeCommandHandler(ICarTypeRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }
        public async Task<string> Handle(DeleteCarTypeCommand request, CancellationToken cancellationToken)
        {
            var _carType = new ProjectQLThueXe.Domain.Entities.CarType { CarType_ID = request.CarType_ID};
            await _carTypeRepository.DeleteAsync(_carType.CarType_ID);
            return "Success";
        }
    }
}
