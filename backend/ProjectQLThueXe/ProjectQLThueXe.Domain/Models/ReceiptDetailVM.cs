using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Models
{
    public class ReceiptDetailVM
    {
        public Guid Car_ID { get; set; }
        public string Car_Model { get; set; } = string.Empty;
        public double Car_Price { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }

    }
}
