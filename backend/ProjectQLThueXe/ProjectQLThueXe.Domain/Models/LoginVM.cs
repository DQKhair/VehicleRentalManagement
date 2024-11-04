using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Models
{
    public class LoginVM
    {
        [Required]
        [RegularExpression(@"^(03|05|07|08|09|01[2|6|8|9])\d{8}$", ErrorMessage = "Invalid phone number format.")]
        public string PhoneNumber { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage = "Pasword can't be more than 50 characters")]
        public string Password { get; set; }
    }
}
