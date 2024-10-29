using MediatR;
using KTVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.KT.Queries
{
    public class GetKTByIdQueryHandler : IRequestHandler<GetKTByIdQuery, KTVM::KT>
    {
        private readonly IKTRepository _ktRepository;
        public GetKTByIdQueryHandler(IKTRepository ktRepository)
        {
            _ktRepository = ktRepository;
        }
        public async Task<KTVM.KT> Handle(GetKTByIdQuery request, CancellationToken cancellationToken)
        {
            return await _ktRepository.GetByIdAsync(request.KT_ID);
        }
    }
}
