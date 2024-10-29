using MediatR;
using ProjectQLThueXe.Domain.Entities;
using KCTVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KCT.Queries
{
    public class GetAllKCTQuery : IRequest<IEnumerable<KCTVM::KCT>>{}
}
