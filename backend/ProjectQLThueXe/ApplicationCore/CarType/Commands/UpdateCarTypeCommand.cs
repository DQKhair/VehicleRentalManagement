﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.CarType.Commands
{
    public class UpdateCarTypeCommand : IRequest<string>
    {
        public int CarType_ID { get; set; }
        public string CarTypeName { get; set; } = string.Empty;
    }
}