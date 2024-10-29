using ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Models
{
    public class ReceiptVM
    {
        public Guid KT_ID { get; set; }
        public List<ReceiptDetailVM> receiptDetails { get; set; } = new List<ReceiptDetailVM>();
    }
}
