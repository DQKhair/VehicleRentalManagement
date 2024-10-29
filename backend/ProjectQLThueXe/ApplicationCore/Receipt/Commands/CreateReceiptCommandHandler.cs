using MediatR;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;
using ProjectQLThueXe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Receipt.Commands
{
    public class CreateReceiptCommandHandler : IRequestHandler<CreateReceiptCommand, Receipts>
    {
        private readonly IReceiptRepository _receiptRepository;
        public CreateReceiptCommandHandler(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<Receipts> Handle(CreateReceiptCommand request, CancellationToken cancellationToken)
        {
            var _receiptVM = new ReceiptVM
            {
                KT_ID = request.KT_ID,
                receiptDetails = request.receiptDetails,
            };
            var addedReceipt = await _receiptRepository.AddAsync(_receiptVM);
            return addedReceipt;
        }
    }
}
