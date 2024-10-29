using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KCT.Commands
{
    public class DeleteKCTCommand : IRequest<string>
    {
        public Guid KCT_ID { get; set; }
    }
}
