﻿using MediatR;
using KCTVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectQLThueXe.Domain.Interfaces;

namespace ProjectQLThueXe.Application.KCT.Commands
{
    public class UpdateKCTCommnadHandler : IRequestHandler<UpdateKCTCommand, KCTVM::KCT>
    {
        private readonly IKCTRepository _kctRepository;

        public UpdateKCTCommnadHandler(IKCTRepository kctRepository) {
            _kctRepository = kctRepository;
        }
        public async Task<KCTVM::KCT> Handle(UpdateKCTCommand request, CancellationToken cancellationToken)
        {
            var _kct = new KCTVM::KCT
            {
                KCT_ID = request.KCT_ID,
                KCT_Name = request.KCT_Name,
                KCT_Phone = request.KCT_Phone,
                KCT_address = request.KCT_Address,
                KCT_CCCD = request.KCT_CCCD,
            };
            await _kctRepository.UpdateAsync(request.KCT_ID, _kct);
            return _kct;
        }
    }
}
