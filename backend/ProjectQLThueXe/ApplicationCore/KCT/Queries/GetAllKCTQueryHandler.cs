using MediatR;
using KCTVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.KCT.Queries
{
    public class GetAllKCTQueryHandler : IRequestHandler<GetAllKCTQuery, IEnumerable<KCTVM::KCT>>
    {
        private readonly IKCTRepository _kctRepository;
        public GetAllKCTQueryHandler(IKCTRepository kctRepository)
        {
            _kctRepository = kctRepository;
        }
        public async Task<IEnumerable<KCTVM::KCT>> Handle(GetAllKCTQuery request, CancellationToken cancellationToken)
        {
            return await _kctRepository.GetAllAsync();
        }
    }
}
