using Microsoft.EntityFrameworkCore;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;
using ProjectQLThueXe.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Infrastructure.Repositories
{
    public class ReceiptDetailRepository : IReceiptDetailRepository
    {
        private readonly MyDBContext _context;
        public ReceiptDetailRepository(MyDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ReceiptDetail>> GetAll()
        {
            return await _context.ReceiptsDetail.ToListAsync();
        }

    }
}
