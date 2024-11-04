using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Receipt.Commands
{
    public class ConfirmReceiptCommand : IRequest<Entity::Receipts>
    {
        public Guid Receipt_ID { get; set; }
    }
}
