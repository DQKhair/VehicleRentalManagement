using MediatR;
using ProjectQLThueXe.Domain.DTOs;
using ProjectQLThueXe.Domain.Models;
using CarTypeVM = ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Queries
{
    public class GetAllCarTypeQueryHandler : IRequestHandler<GetAllCarTypeQuery, IEnumerable<CarTypeVM::CarType>>
    {
        private readonly ICarTypeRepository _carTypeRepository;

        public GetAllCarTypeQueryHandler(ICarTypeRepository carTypeRepository)
        {
            _carTypeRepository = carTypeRepository;
        }

        public async Task<IEnumerable<CarTypeVM::CarType>> Handle(GetAllCarTypeQuery request, CancellationToken cancellationToken)
        {
            return await _carTypeRepository.GetAllAsync();
        }
    }
}
