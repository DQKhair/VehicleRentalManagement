using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Entities
{
    [Table("CarStatus")]
    public class CarStatus
    {
        [Key]
        public int CarStatus_ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string CarStatusName { get; set; }

        //relationship
        public ICollection<Car> Cars { get; set; }
        public CarStatus()
        {
            Cars = new List<Car>();
        }
    }
}
