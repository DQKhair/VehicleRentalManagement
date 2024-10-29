using MediatR;
using KTVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;
using ProjectQLThueXe.Application.Car.Queries;

namespace ProjectQLThueXe.Application.KT.Queries
{
    public class GetlAllKTQueryHandler : IRequestHandler<GetAllKTQuery, IEnumerable<KTVM::KT>>
    {
        private readonly IKTRepository _ktRepository;
        public GetlAllKTQueryHandler(IKTRepository ktRepository)
        {
            _ktRepository = ktRepository;
        }
        public async Task<IEnumerable<KTVM::KT>> Handle(GetAllKTQuery request, CancellationToken cancellationToken)
        {
            return await _ktRepository.GetAllAsync();
        }
    }
}
