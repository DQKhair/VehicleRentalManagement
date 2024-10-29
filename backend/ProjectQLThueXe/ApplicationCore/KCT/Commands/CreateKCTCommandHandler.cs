using MediatR;
using KCTVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.KCT.Commands
{
    public class CreateKCTCommandHandler : IRequestHandler<CreateKCTCommand, KCTVM::KCT>
    {
        private readonly IKCTRepository _kctRepository;
        public CreateKCTCommandHandler(IKCTRepository kctRepository)
        {
            _kctRepository = kctRepository;
        }
        public async Task<KCTVM::KCT> Handle(CreateKCTCommand request, CancellationToken cancellationToken)
        {
            var _kct = new KCTVM::KCT
            {
                KCT_ID = Guid.NewGuid(),
                KCT_Name = request.KCT_Name,
                KCT_Phone = request.KCT_Phone,
                KCT_address = request.KCT_Address,
                KCT_CCCD = request.KCT_CCCD,
            };
            await _kctRepository.AddAsync(_kct);
            return _kct;
        }
    }
}
