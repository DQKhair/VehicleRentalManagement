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
    public class ConfirmReceiptCommandHandler : IRequestHandler<ConfirmReceiptCommand, Entity::Receipts>
    {
        private readonly IReceiptRepository _receiptRepository;
        public ConfirmReceiptCommandHandler(IReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task<Receipts> Handle(ConfirmReceiptCommand request, CancellationToken cancellationToken)
        {
            return await _receiptRepository.ConfirmRentCar(request.Receipt_ID);
        }
    }
}
