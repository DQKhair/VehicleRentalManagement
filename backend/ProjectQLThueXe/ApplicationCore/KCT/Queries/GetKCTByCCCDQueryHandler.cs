using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.KCT.Queries
{
    public class GetKCTByCCCDQueryHandler : IRequestHandler<GetKCTByCCCDQuery, Entity::KCT>
    {
        private readonly IKCTRepository _kctrepository;
        public GetKCTByCCCDQueryHandler(IKCTRepository kctrepository)
        {
            _kctrepository = kctrepository;
        }

        public async Task<Entity::KCT> Handle(GetKCTByCCCDQuery request, CancellationToken cancellationToken)
        {
            return await _kctrepository.GetByCCCDAsync(request.KCT_CCCD);
        }
    }
}
