using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Models;
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
        Task<Car> AddAsync(PostCarVM postCarVM);
        Task<bool> UpdateAsync(Guid id, Car car);
        Task<bool> DeleteAsync(Guid id);
        Task<Car> UpdateLocationAsync(Guid id,string location);
        Task<Car> ReturnCarAsync(Guid id, Guid kt_ID);
    }
}
