using MediatR;
using ProjectQLThueXe.Domain.Interfaces;
using CarTypeVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Queries
{
    public class GetCarTypeByIdQueryHandler : IRequestHandler<GetCarTypeByIdQuery, CarTypeVM::CarType>
    {
        private readonly ICarTypeRepository _carTypeRepository;
        public GetCarTypeByIdQueryHandler(ICarTypeRepository carTypeRepository) 
        {
            _carTypeRepository = carTypeRepository; 
        }
        public async Task<Domain.Entities.CarType> Handle(GetCarTypeByIdQuery request, CancellationToken cancellationToken)
        {
            //var _carType = CarType { CarType_ID = request.CarType_ID };
            return await _carTypeRepository.GetByIdAsync(request.CarType_ID);
        }
    }
}
