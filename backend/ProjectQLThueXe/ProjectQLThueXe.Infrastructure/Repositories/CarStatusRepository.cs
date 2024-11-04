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
    public class CarStatusRepository : ICarStatusRepository
    {
        private readonly MyDBContext _context;
        public CarStatusRepository(MyDBContext context) {
            _context = context;
        }
        public async Task<IEnumerable<CarStatus>> GetAllAsync()
        {
            return await _context.CarStatus.ToListAsync();
        }
    }
}
