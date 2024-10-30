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
    public class GetKTByPhoneQueryHandler : IRequestHandler<GetKTByPhoneQuery, Entity::KT>
    {
        private readonly IKTRepository _ktRepository;
        public GetKTByPhoneQueryHandler(IKTRepository ktRepository)
        {
            _ktRepository = ktRepository;
        }

        public async Task<Entity::KT> Handle(GetKTByPhoneQuery request, CancellationToken cancellationToken)
        {
            return await _ktRepository.GetByPhoneAsync(request.KT_Phone);
        }
    }
}
