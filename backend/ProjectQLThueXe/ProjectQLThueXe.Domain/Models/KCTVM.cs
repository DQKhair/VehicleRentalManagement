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
        [RegularExpression(@"^(03|05|07|08|09|01[2|6|8|9])\d{8}$", ErrorMessage = "Invalid phone number format.")]
        public string KCT_Phone { get; set; }
        [MaxLength(100)]
        public string KCT_Address { get; set; }
        [Required]
        [MaxLength(12,ErrorMessage = "CCCD invalid")]
        public string KCT_CCCD { get; set; }
    }
}
