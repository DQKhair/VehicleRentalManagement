using MediatR;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Receipt.Commands
{
    public class ConfirmReturnCarCommandHandler : IRequestHandler<ConfirmReturnCarCommand, Receipts>
    {
        private readonly IReceiptRepository _receiptRepository;
        public ConfirmReturnCarCommandHandler(IReceiptRepository receiRepository)
        {
            _receiptRepository = receiRepository;
        }
        public async Task<Receipts> Handle(ConfirmReturnCarCommand request, CancellationToken cancellationToken)
        {
            return await _receiptRepository.ConfirmReturnCar(request.Receipt_ID);
        }
    }
}
