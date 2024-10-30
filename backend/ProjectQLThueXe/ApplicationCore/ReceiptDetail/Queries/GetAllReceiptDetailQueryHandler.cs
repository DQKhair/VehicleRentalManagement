using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.ReceiptDetail.Queries
{
    public class GetAllReceiptDetailQueryHandler : IRequestHandler<GetAllReceiptDetailQuery,IEnumerable<Entity::ReceiptDetail>>
    {
        private readonly IReceiptDetailRepository _receiptDetailRepository;
        public GetAllReceiptDetailQueryHandler(IReceiptDetailRepository receiptDetailRepository)
        {
            _receiptDetailRepository = receiptDetailRepository;
        }
        public async Task<IEnumerable<Entity::ReceiptDetail>> Handle(GetAllReceiptDetailQuery request, CancellationToken cancellationToken)
        {
            return await _receiptDetailRepository.GetAll();
        }
    }
}
