using ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Interfaces
{
    public interface IKTRepository
    {
        Task<IEnumerable<KT>> GetAllAsync();
        Task<KT> GetByIdAsync(Guid id);
        Task<bool> AddAsync(KT kt);
        Task<bool> UpdateAsync(Guid id, KT kT);
        Task<bool> DeleteAsync(Guid id);
    }
}
