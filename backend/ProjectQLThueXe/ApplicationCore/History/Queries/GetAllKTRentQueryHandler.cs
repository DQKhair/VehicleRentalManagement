using MediatR;
using ProjectQLThueXe.Domain.Interfaces;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.History.Queries
{
    public class GetAllKTRentQueryHandler : IRequestHandler<GetAllKTRentQuery, IEnumerable<Entity::Receipts>>
    {
        private readonly IHistoryKTRepository _historyKTRepository;
        public GetAllKTRentQueryHandler(IHistoryKTRepository historyKTRepository)
        {
            _historyKTRepository = historyKTRepository;
        }

        public async Task<IEnumerable<Entity::Receipts>> Handle(GetAllKTRentQuery request, CancellationToken cancellationToken)
        {
            return await _historyKTRepository.GetAllKTRentAsync();
        }
    }
}
