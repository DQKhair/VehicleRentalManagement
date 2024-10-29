using MediatR;
using ProjectQLThueXe.Domain.Entities;
using KCTVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KCT.Commands
{
    public class CreateKCTCommand : IRequest<KCTVM::KCT>
    {
        public string KCT_Name { get; set; } = String.Empty;
        public string KCT_Phone { get; set; } = String.Empty;
        public string KCT_Address {  get; set; } = String.Empty;
        public string KCT_CCCD {  get; set; } = String.Empty;
    }
}
