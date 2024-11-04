using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Entities
{
    [Table("ReceiptStatus")]
    public class ReceiptStatus
    {
        [Key]
        public int ReceiptStatus_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string ReceiptstatusName { get; set; } = string.Empty;

        //relationship
        public ICollection<Receipts> Receipts { get; set; }
        public ReceiptStatus() 
        {
            Receipts = new List<Receipts>();
        }
    }
}
