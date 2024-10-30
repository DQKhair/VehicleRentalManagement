using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KT.Queries
{
    public class GetKTByCCCDQuery : IRequest<Entity::KT>
    {
        public string KT_CCCD {  get; set; } = string.Empty;
    }
}
