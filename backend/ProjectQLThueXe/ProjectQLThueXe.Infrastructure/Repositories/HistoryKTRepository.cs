using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
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
    public class HistoryKTRepository : IHistoryKTRepository
    {
        private readonly MyDBContext _Context;
        public HistoryKTRepository(MyDBContext context)
        {
            _Context = context;
        }
        public async Task<IEnumerable<Receipts>> GetAllKTRentAsync()
        {
            return await _Context.Receipts.Where(e => e.ReceiptStatus_ID != 1 && e.ReceiptStatus_ID != 3).ToListAsync();
        }

        public async Task<Receipts> GetKTRentByIdAsync(Guid id)
        {
            var _receipt = await _Context.Receipts.FirstOrDefaultAsync(e => e.ReceiptStatus_ID != 1 && e.ReceiptStatus_ID != 3 && e.KT_ID == id);
            if (_receipt != null) 
            {
                return _receipt;
            }
            return null!;
        }
    }
}
