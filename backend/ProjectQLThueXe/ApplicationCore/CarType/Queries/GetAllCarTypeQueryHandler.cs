using MediatR;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Queries
{
    public class GetAllCarTypeQueryHandler : IRequestHandler<GetAllCarTypeQuery, IEnumerable<ProjectQLThueXe.Domain.Entities.CarType>>
    {
        private readonly ICarTypeRepository _carTypeRepository;

        public GetAllCarTypeQueryHandler(ICarTypeRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }

        public async Task<IEnumerable<Domain.Entities.CarType>> Handle(GetAllCarTypeQuery request, CancellationToken cancellationToken)
        {
            return await _carTypeRepository.GetAllAsync();
        }
    }
}
