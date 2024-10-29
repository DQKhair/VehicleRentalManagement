using MediatR;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.KT.Commands
{
    public class DeleteKTCommanHandler : IRequestHandler<DeleteKTCommand, string>
    {
        private readonly IKTRepository _ktRepository;
        public DeleteKTCommanHandler(IKTRepository ktRepository)
        {
            _ktRepository = ktRepository;
        }

        public async Task<string> Handle(DeleteKTCommand request, CancellationToken cancellationToken)
        {
            await _ktRepository.DeleteAsync(request.KT_ID);
            return "Success";
        }
    }
}
