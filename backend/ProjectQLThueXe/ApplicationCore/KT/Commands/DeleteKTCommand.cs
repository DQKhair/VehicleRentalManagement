using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KT.Commands
{
    public class DeleteKTCommand : IRequest<string>
    {
        public Guid KT_ID { get; set; }
    }
}
