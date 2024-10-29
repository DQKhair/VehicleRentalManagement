using MediatR;
using KTVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.KT.Commands
{
    public class UpdateKTCommandHandler : IRequestHandler<UpdateKTCommand, KTVM::KT>
    {
        private readonly IKTRepository _ktRepository;
        public UpdateKTCommandHandler(IKTRepository ktRepository)
        {
            _ktRepository = ktRepository;
        }
        public async Task<KTVM::KT> Handle(UpdateKTCommand request, CancellationToken cancellationToken)
        {
           var _kt = new KTVM::KT 
           {
               KT_ID = request.KT_ID,
               KT_Name = request.KT_Name,
               KT_Phone = request.KT_Phone,
               KT_Address = request.KT_Address,
               KT_CCCD = request.KT_CCCD,
           };
            await _ktRepository.UpdateAsync(_kt.KT_ID, _kt);
            return _kt;
        }
    }
}
