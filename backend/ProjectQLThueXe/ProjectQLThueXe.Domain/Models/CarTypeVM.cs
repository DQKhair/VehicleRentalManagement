using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Models
{
    public class CarTypeVM
    {
        [Required]
        [MaxLength(50,ErrorMessage = "Name must be less than 50 characters")]
        public string CarTypeName { get; set; }
    }
}
