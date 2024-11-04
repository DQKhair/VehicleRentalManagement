using ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Models
{
    public class ReceiptVM
    {
        [Required]
        public Guid KT_ID { get; set; }
        [MaxLength(200)]
        public string? ReceiptDescription { get; set; } = string.Empty;
        [Required]
        public ReceiptDetailVM receiptDetails { get; set; }
    }
}
