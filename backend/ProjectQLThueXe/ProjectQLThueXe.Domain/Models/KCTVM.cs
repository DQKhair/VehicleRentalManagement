using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Models
{
    public class KCTVM
    {
        [Required]
        [MaxLength(50,ErrorMessage = "Name must be less than 50 characters")]
        public string KCT_Name { get; set; }
        [Required]
        [MaxLength(12,ErrorMessage ="Phone invalid")]
        public string KCT_Phone { get; set; }
        [MaxLength(100)]
        public string KCT_Address { get; set; }
        [Required]
        [MaxLength(12,ErrorMessage = "CCCD invalid")]
        public string KCT_CCCD { get; set; }
    }
}
