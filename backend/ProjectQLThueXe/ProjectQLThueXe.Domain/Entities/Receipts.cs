using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Entities
{
    [Table("Receipts")]
    public class Receipts
    {
        [Key]
        public Guid Receipt_ID { get; set; }
        [Range(0,100000000)]
        public double totalMoney { get; set; }
        public DateTime ReceiptTime { get; set; } = DateTime.Now;
        [MaxLength(200)]
        public string? ReceiptDescription { get; set; }

        public Guid? KT_ID { get; set; }
        [ForeignKey(nameof(KT_ID))]
        public int? ReceiptStatus_ID { get; set; }
        [ForeignKey(nameof(ReceiptStatus_ID))]

        //relationship
        public KT? KT { get; set; }
        public ReceiptStatus? ReceiptStatus { get; set; }

        public ICollection<ReceiptDetail> ReceiptDetails { get; set; }

        public Receipts()
        {
            ReceiptDetails = new List<ReceiptDetail>();
        }
    }
}
