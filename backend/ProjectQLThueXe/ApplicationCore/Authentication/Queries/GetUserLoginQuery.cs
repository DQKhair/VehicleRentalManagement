using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Authentication.Queries
{
    public class GetUserLoginQuery : IRequest<Entity::KT>
    {
        public string PhoneNumber { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
    }
}
