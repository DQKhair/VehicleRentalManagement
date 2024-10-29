using MediatR;
using KTVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KT.Queries
{
    public class GetAllKTQuery : IRequest<IEnumerable<KTVM::KT>>{}
}
