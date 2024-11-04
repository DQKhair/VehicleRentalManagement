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
    public class ReceiptStatusRepository : IReceiptStatusRepository
    {
        private readonly MyDBContext _context;
        public ReceiptStatusRepository(MyDBContext context)
        { 
            _context = context; 
        }
        public async Task<IEnumerable<ReceiptStatus>> GetAllAsync()
        {
           return await _context.ReceiptStatuses.ToListAsync();
        }
    }
}
