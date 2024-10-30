using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KCT.Queries
{
    public class GetKCTByCCCDQuery : IRequest<Entity::KCT>
    {
        public string KCT_CCCD { get; set; }  = string.Empty;
    }
}
