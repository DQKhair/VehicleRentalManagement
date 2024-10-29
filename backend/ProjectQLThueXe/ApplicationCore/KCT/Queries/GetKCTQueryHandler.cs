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
    public class GetKCTQueryHandler : IRequestHandler<GetKCTByIdQuery, KCTVM::KCT>
    {
        private readonly IKCTRepository _kctRepository;
        public GetKCTQueryHandler(IKCTRepository kctRepository)
        {
            _kctRepository = kctRepository;
        }
        public async Task<KCTVM.KCT> Handle(GetKCTByIdQuery request, CancellationToken cancellationToken)
        {
            return await _kctRepository.GetByIdAsync(request.KCT_ID);
        }
    }
}
