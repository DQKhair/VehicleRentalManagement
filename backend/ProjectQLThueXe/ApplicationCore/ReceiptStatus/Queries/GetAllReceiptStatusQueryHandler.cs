using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.ReceiptStatus.Queries
{
    public class GetAllReceiptStatusQueryHandler : IRequestHandler<GetAllReceiptStatusQuery, IEnumerable<Entity::ReceiptStatus>>
    {
        private readonly IReceiptStatusRepository _receiptStatusRepository;
        public GetAllReceiptStatusQueryHandler(IReceiptStatusRepository receiptStatusRepository)
        {
            _receiptStatusRepository = receiptStatusRepository;
        }
        public async Task<IEnumerable<Entity.ReceiptStatus>> Handle(GetAllReceiptStatusQuery request, CancellationToken cancellationToken)
        {
            return await _receiptStatusRepository.GetAllAsync();
        }
    }
}
