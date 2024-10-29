using MediatR;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Receipt.Commands
{
    public class CreateReceiptCommand : IRequest<Receipts>
    {
        public Guid KT_ID { get; set; }
        public List<ReceiptDetailVM> receiptDetails { get; set; } = new List<ReceiptDetailVM>();
    }
}
