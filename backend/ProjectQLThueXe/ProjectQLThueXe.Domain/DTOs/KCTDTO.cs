using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.DTOs
{
    public class KCTDTO
    {      
        public Guid KCT_ID { get; set; }
        public string KCT_Name {  get; set; } = string.Empty;
        public string KCT_Phone { get; set; } = string.Empty;
        public string KCT_Address {  get; set; } = string.Empty;
        public string KCT_CCCD { get; set; } = string.Empty;
    }
}
