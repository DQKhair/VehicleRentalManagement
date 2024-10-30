using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Models
{
    public class CarVM
    {
        [Required]
        [MaxLength(50,ErrorMessage = "Model must be less than 50 characters")]
        public string Model { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage = "Number plate invalid")]
        public string NumberPlate { get; set; }
        [Required]
        [Range(1,100000000)]
        public double Price { get; set; }
        public string Location { get; set; }
        public bool Status { get; set; }
        public int CarType_ID { get; set; }
        public Guid KCT_ID { get; set; }
    }
}
