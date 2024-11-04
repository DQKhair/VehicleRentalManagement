using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.ReceiptStatus.Queries
{
    public class GetAllReceiptStatusQuery : IRequest<IEnumerable<Entity::ReceiptStatus>>
    {
    }
}
