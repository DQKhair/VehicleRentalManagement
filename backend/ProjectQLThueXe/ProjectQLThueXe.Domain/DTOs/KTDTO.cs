using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.DTOs
{
    public class KTDTO
    {
        public Guid KT_ID { get; set; }
        public string KT_Name { get; set; } = string.Empty;
        public string KT_Phone { get; set; } = string.Empty;
        public string KT_Address { get; set; } = string.Empty;
        public string KT_CCCD { get; set; } = string.Empty;
    }
}
