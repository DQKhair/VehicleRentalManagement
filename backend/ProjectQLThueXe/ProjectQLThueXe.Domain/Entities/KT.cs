using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Entities
{
    [Table("KT")]
    public class KT
    {
        [Key]
        public Guid KT_ID { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string KT_Name { get; set; } = string.Empty;
        [MaxLength(12)]
        public string KT_Phone { get; set; } = string.Empty;
        [MaxLength (100)]
        public string KT_Address { get; set; } = string.Empty;
        [MaxLength(12)]
        [Required]
        public string KT_CCCD { get; set; } = string.Empty;

        public ICollection<Receipts> Receipts { get; set; }

        public KT()
        {
            Receipts = new List<Receipts>();
        }
    }
}
