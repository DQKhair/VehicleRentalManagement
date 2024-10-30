using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.CarType.Queries
{
    public class GetCarTypeByNameQueryHandler : IRequestHandler<GetCarTypeByNameQuery, Entity::CarType>
    {
        private readonly ICarTypeRepository _carTypeRepository;
        public GetCarTypeByNameQueryHandler(ICarTypeRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }
        public async Task<Entity::CarType> Handle(GetCarTypeByNameQuery request, CancellationToken cancellationToken)
        {
            return await _carTypeRepository.GetByNameAsync(request.CarTypeName);
        }
    }
}
