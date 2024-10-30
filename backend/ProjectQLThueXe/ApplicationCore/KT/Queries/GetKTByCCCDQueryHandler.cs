using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.KT.Queries
{
    public class GetKTByCCCDQueryHandler : IRequestHandler<GetKTByCCCDQuery, Entity::KT>
    {
        private readonly IKTRepository _ktRepository;
        public GetKTByCCCDQueryHandler(IKTRepository ktRepository)
        {
            _ktRepository = ktRepository;
        }
        public async Task<Entity::KT> Handle(GetKTByCCCDQuery request, CancellationToken cancellationToken)
        {
            return await _ktRepository.GetByCCCDAsync(request.KT_CCCD);
        }
    }
}
