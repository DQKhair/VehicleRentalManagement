using MediatR;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.Receipt.Commands
{
    public class RejectReceiptCommandHandler : IRequestHandler<RejectReceiptCommand, Entity::Receipts>
    {
        private readonly IReceiptRepository _receiptRepository;
        public RejectReceiptCommandHandler(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }
        public async Task<Receipts> Handle(RejectReceiptCommand request, CancellationToken cancellationToken)
        {
           return await _receiptRepository.RejectRentcar(request.Receipt_ID);
        }
    }
}
