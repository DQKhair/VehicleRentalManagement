using MediatR;
using KCTVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KCT.Queries
{
    public class GetKCTByIdQuery : IRequest<KCTVM::KCT>
    {
        public Guid KCT_ID { get; set; }
    }
}
