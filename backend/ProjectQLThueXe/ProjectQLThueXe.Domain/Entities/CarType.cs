using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Entities
{
    [Table("CarType")]
    public class CarType
    {
        [Key]
        public int CarType_ID { get; set; }
        [MaxLength(50)]
        [MinLength(1)]
        [Required]
        public string CarTypeName { get; set; } = string.Empty;

        //relationship
        public ICollection<Car> Cars { get; set; }

        public CarType()
        {
            Cars = new List<Car>();
        }

    }
}
