using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Models
{
    public class ReceiptDetailVM
    {
        [Required]
        public Guid Car_ID { get; set; }
        public string Car_Model { get; set; }
        [Range(1,100000000)]
        public double Car_Price { get; set; }
        [Required]
        public DateTime TimeStart { get; set; }
        [Required]
        public DateTime TimeEnd { get; set; }

    }
}
