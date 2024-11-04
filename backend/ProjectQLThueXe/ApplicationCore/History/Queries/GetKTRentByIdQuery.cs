using MediatR;
using ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.History.Queries
{
    public class GetKTRentByIdQuery : IRequest<Receipts>
    {
        public Guid KT_ID { get; set; }
    }
}
