using MediatR;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.History.Queries
{
    public class GetKTRentByIdQueryHandler : IRequestHandler<GetKTRentByIdQuery, Receipts>
    {
        private readonly IHistoryKTRepository _historyKTRepository;
        public GetKTRentByIdQueryHandler(IHistoryKTRepository historyKTRepository)
        {
            _historyKTRepository = historyKTRepository;
        }
        public async Task<Receipts> Handle(GetKTRentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _historyKTRepository.GetKTRentByIdAsync(request.KT_ID);
        }
    }
}
