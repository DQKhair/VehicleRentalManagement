using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ProjectQLThueXe.Domain.Entities
{
    [Table("Car")]
    public class Car
    {
        [Key]
        public Guid Car_ID { get; set; }
        [MaxLength(50)]
        [MinLength(1)]
        [Required]
        public string Model { get; set; } = string.Empty;
        [Range(0, 100000000)]
        public double Price { get; set; }
        [Required]
        [MaxLength(10)]
        public string NumberPlate { get; set; }
        public bool status { get; set; }
        public string location { get; set; } = string.Empty;
        public string? locationX { get; set; }
        public string? locationY { get; set; }
        public string? URLImage { get; set; }

        public int? CarStatus_ID { get; set; }
        [ForeignKey(nameof(CarStatus_ID))]
        public int? CarType_ID { get; set; }
        [ForeignKey(nameof(CarType_ID))]
        public Guid? KCT_ID { get; set; }
        [ForeignKey(nameof(KCT_ID))]

        //relationship
        public CarStatus? CarStatus { get; set; }
        public CarType? CarType { get; set; }
        public KCT? KCT { get; set; }

        public ICollection<ReceiptDetail> ReceiptDetails { get; set; }
        public Car()
        {
            ReceiptDetails = new List<ReceiptDetail>();
        }
    }
}
