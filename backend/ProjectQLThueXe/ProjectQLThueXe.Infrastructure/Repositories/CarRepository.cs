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
    public class CarRepository : ICarRepository
    {
        private readonly MyDBContext _context;
        public CarRepository(MyDBContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Car car)
        {
            if(car != null )
            {
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();
                return true;
            }   
            return false;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                var _car = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == id);
                if (_car != null)
                {
                    _context.Cars.Remove(_car);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetByIdAsync(Guid id)
        {
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                //var _car = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == id);
                var _car = await _context.Cars.FindAsync(id);
                if(_car != null)
                {
                    return _car;
                }    
            }
            return null!;
        }

        public async Task<bool> UpdateAsync(Guid id, Car car)
        {
            if (!String.IsNullOrEmpty(id.ToString()) && car != null)
            {
                var _car = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == id);
                if(_car != null)
                {
                    _car.Model = car.Model;
                    _car.Price = car.Price;
                    _car.NumberPlate = car.NumberPlate;
                    _car.location = car.location;
                    _car.status = car.status;
                    _car.CarType_ID = car.CarType_ID;
                    _car.KCT_ID = car.KCT_ID;

                    await _context.SaveChangesAsync();
                    return true;
                }    
            }
            return false;
        }

        public async Task<Car> UpdateLocationAsync(Guid id, string location)
        {
            if(String.IsNullOrEmpty(location))
            {
                return null!;
            }
            var _car = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == id);
            if (_car != null)
            {
                _car.location = location;
                await _context.SaveChangesAsync();
                var _updated = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == id);
                if (_updated != null)
                {
                    return _updated;
                }
            }
            return null!; ;
        }
    }
}
