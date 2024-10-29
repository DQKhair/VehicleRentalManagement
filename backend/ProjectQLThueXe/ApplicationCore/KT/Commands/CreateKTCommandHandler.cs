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
    public class CreateKTCommandHandler : IRequestHandler<CreateKTCommand, KTVM::KT>
    {
        private readonly IKTRepository _ktRepository;
        public CreateKTCommandHandler(IKTRepository ktRepository)
        {
            _ktRepository = ktRepository;
        }

        public async Task<KTVM::KT> Handle(CreateKTCommand request, CancellationToken cancellationToken)
        {
            var _kt = new KTVM::KT
            {
                KT_ID = Guid.NewGuid(),
                KT_Name = request.KT_Name,
                KT_Phone = request.KT_Phone,
                KT_Address = request.KT_Address,
                KT_CCCD = request.KT_CCCD,
            };
            await _ktRepository.AddAsync(_kt);
            return _kt;
        }
    }
}
