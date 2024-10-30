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
    public class CarTypeRepository : ICarTypeRepository
    {
        private readonly MyDBContext _context;

        public CarTypeRepository(MyDBContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(CarType carType)
        {
            if (carType == null)
            {
                return false;
            }
            await _context.CarTypes.AddAsync(carType);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if(id >0)
            {
                var _carType = await _context.CarTypes.FindAsync(id);
                if (_carType != null)
                {    
                    _context.CarTypes.Remove(_carType);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<CarType>> GetAllAsync()
        {
            return await _context.CarTypes.ToListAsync();
        }

        public async Task<CarType> GetByIdAsync(int id)
        {
            if(id > 0)
            {
                var _carType = await _context.CarTypes.FindAsync(id);
                if (_carType != null)
                {
                    return _carType;
                }
            }
            return null!;
        }

        public async Task<CarType> GetByNameAsync(string carTypeName)
        {
           if(!String.IsNullOrEmpty(carTypeName))
            {
                var _cartype = await _context.CarTypes.FirstOrDefaultAsync(e => e.CarTypeName == carTypeName);
                if( _cartype != null )
                {
                    return _cartype;
                }    
            }
            return null!;
        }

        public async Task<bool> UpdateAsync(int id, CarType carType)
        {
            if(id > 0 && carType != null)
            {
                var _carType = await _context.CarTypes.FindAsync(id);
                if (_carType != null)
                {
                    _carType.CarTypeName = carType.CarTypeName;
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

       
    }
}
