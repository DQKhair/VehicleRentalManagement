using MediatR;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KT.Commands
{
    public class CancelRentCarCommandHandler : IRequestHandler<CancelRentCarCommand, string>
    {
       private readonly IKTRepository _ktRepository;
        public CancelRentCarCommandHandler(IKTRepository ktRepository)
        {
            _ktRepository = ktRepository;
        }
        public async Task<string> Handle(CancelRentCarCommand request, CancellationToken cancellationToken)
        {
            var _result = await _ktRepository.CancelRentCar(request.Car_ID, request.KT_ID);
            if(_result)
            {
                return "Cancel successful";
            }
            return null!;
        }
    }
}
