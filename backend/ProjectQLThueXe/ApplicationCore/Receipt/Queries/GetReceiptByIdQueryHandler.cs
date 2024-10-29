using MediatR;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Receipt.Queries
{
    public class GetReceiptByIdQueryHandler : IRequestHandler<GetReceiptByIdQuery, Receipts>
    {
        private readonly IReceiptRepository _receiptRepository;
        public GetReceiptByIdQueryHandler(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<Receipts> Handle(GetReceiptByIdQuery request, CancellationToken cancellationToken)
        {
            return await _receiptRepository.GetByIdAsync(request.Receipt_ID);
        }
    }
}
