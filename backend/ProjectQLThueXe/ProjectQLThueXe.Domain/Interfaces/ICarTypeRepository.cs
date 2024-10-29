using ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Interfaces
{
    public interface ICarTypeRepository
    {
        Task<IEnumerable<CarType>> GetAllAsync();
        Task<CarType> GetByIdAsync(int id);
        Task<bool> AddAsync(CarType carType);
        Task<bool> UpdateAsync(int id, CarType carType);
        Task<bool> DeleteAsync(int id);
    }
}
