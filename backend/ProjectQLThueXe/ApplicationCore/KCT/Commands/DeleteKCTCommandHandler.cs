using MediatR;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KCT.Commands
{
    public class DeleteKCTCommandHandler : IRequestHandler<DeleteKCTCommand, string>
    {
        private readonly IKCTRepository _kctRepository;
        public DeleteKCTCommandHandler(IKCTRepository kctRepository)
        {
            _kctRepository = kctRepository;
        }
        public async Task<string> Handle(DeleteKCTCommand request, CancellationToken cancellationToken)
        {
            await _kctRepository.DeleteAsync(request.KCT_ID);
            return "Success";
        }
    }
}
