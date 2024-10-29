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
    public class GetAllReceiptQueryHandler : IRequestHandler<GetAllReceiptQuery, IEnumerable<Receipts>>
    {
        private readonly IReceiptRepository _receiptRepository;
        public GetAllReceiptQueryHandler(IReceiptRepository receiRepository)
        {
            _receiptRepository = receiRepository;
        }
        public async Task<IEnumerable<Receipts>> Handle(GetAllReceiptQuery request, CancellationToken cancellationToken)
        {
            return await _receiptRepository.GetAllAsync();
        }
    }
}
