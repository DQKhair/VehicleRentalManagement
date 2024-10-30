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
    public class GetKCTByPhoneQueryHandler : IRequestHandler<GetKCTByPhoneQuery, Entity::KCT>
    {
        private readonly IKCTRepository _kctRepository;
        public GetKCTByPhoneQueryHandler(IKCTRepository kctRepository)
        {
            _kctRepository = kctRepository;
        }
        public async Task<Entity::KCT> Handle(GetKCTByPhoneQuery request, CancellationToken cancellationToken)
        {
            return await _kctRepository.GetByPhoneAsync(request.KCT_Phone);
        }
    }
}
