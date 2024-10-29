using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Entities
{
    [Table("ReceiptDetail")]
    public class ReceiptDetail
    {
        [Key]
        public Guid ReceiptDetail_ID { get; set; }
        [MaxLength(50)]
        [Required]
        public string Car_model { get; set; } = string.Empty;
        [Range(0, 100000000)]
        public double Car_Price { get; set; }

        public Guid? Car_ID { get; set; }
        [ForeignKey(nameof(Car_ID))]
        public Guid? Receipt_ID { get; set; }
        [ForeignKey(nameof(Receipt_ID))]

        //relationship
        public Car? Car { get; set; }
        public Receipts? Receipts { get; set; }
    }
}
