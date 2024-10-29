using MediatR;
using KCTVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KCT.Commands
{
    public class UpdateKCTCommand : IRequest<KCTVM::KCT>
    {
        public Guid KCT_ID { get; set; }
        public string KCT_Name { get; set; } = string.Empty;
        public string KCT_Phone {  get; set; } = string.Empty;
        public string KCT_Address { get; set; } = string.Empty;
        public string KCT_CCCD { get; set; } = string.Empty;
    }
}
