using ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByIdAsync(Guid id);
        Task<Car> GetByNumberPlate(string  numberPlate);
        Task<bool> AddAsync(Car car);
        Task<bool> UpdateAsync(Guid id, Car car);
        Task<bool> DeleteAsync(Guid id);
        Task<Car> UpdateLocationAsync(Guid id,string location);
    }
}
