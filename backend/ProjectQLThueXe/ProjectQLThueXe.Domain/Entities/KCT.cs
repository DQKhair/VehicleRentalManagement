using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Entities
{
    [Table("KCT")]
    public class KCT
    {
        [Key]
        public Guid KCT_ID { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(1)]
        public string KCT_Name { get; set; } = string.Empty;
        [MaxLength(12)]
        [Required]
        public string KCT_Phone { get; set; } = string.Empty;
        [MaxLength(100)]
        public string KCT_address { get; set; } = string.Empty;
        [MaxLength(12)]
        [Required]
        public string KCT_CCCD { get; set; } = string.Empty;

        //relationship
        public ICollection<Car> Cars { get; set; }

        public KCT()
        {
            Cars = new List<Car>();
        }
    }
}
