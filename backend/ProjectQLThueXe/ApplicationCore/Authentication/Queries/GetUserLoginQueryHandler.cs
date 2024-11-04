using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.Authentication.Queries
{
    public class GetUserLoginQueryHandler : IRequestHandler<GetUserLoginQuery, Entity::KT>
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public GetUserLoginQueryHandler(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        public async Task<Entity::KT> Handle(GetUserLoginQuery request, CancellationToken cancellationToken)
        {
            return await _authenticationRepository.LoginUserAsync(request.PhoneNumber, request.password);
        }
    }
}
