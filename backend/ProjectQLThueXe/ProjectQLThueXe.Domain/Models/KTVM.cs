﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Models
{
    public class KTVM
    {
        [Required]
        [MaxLength(50,ErrorMessage = "Name must be less than 50 characters")]
        public string KT_Name { get; set; }
        [Required]
        [MaxLength(12,ErrorMessage = "Phone invalid")]
        public string KT_Phone { get; set; }
        [Required]
        [MaxLength(100,ErrorMessage = "Address must be less than 100 characters")]
        public string KT_Address { get; set; }
        [Required]
        [MaxLength(12,ErrorMessage = "CCCD invalid")]
        public string KT_CCCD { get; set; }
    }
}