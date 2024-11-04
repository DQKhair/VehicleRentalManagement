using ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.DTOs
{
    public class ReceiptDTO
    {
        public Guid Receipt_ID { get; set; }
        public double TotalMoney { get; set; }
        public DateTime ReceiptTime { get; set; }
        public int? ReceiptStatus_ID { get; set; }
        public string? ReceiptStatusName { get; set; }
        public Guid? KT_ID { get; set; }
        public string? KT_Name { get; set; }
        public ReceiptDetailDTO? ReceiptDetailDTOs { get; set; }
        public string? ReceiptDescription { get; set; }
    }

    public class ReceiptDetailDTO
    {
        public Guid ReceiptDetail_ID { get; set; }
        public string? Car_model { get; set; }
        public double Car_Price { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int TotalDay { get; set; }

        public Guid? Car_ID { get; set; }
        public Guid? Receipt_ID { get; set; }

    }
}
