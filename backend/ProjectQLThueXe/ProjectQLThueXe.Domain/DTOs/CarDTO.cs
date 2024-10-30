using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.DTOs
{
    public class CarDTO
    {
        public Guid Car_ID { get; set; }
        public string Model { get; set; } = string.Empty;
        public string NumberPlate { get; set; } = string.Empty;
        public double Price { get; set; }
        public string Location { get; set; } = string.Empty;
        public bool Status { get; set; }
        public int? CarType_ID { get; set; }
        public string? CarTypeName { get; set; } = string.Empty;
        public Guid? KCT_ID {  get; set; }
        public string? KCT_Name { get; set; } = string.Empty;
    }
}
