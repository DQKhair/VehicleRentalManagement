using ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Interfaces
{
    public interface IKCTRepository
    {
        Task<IEnumerable<KCT>> GetAllAsync();
        Task<KCT> GetByIdAsync(Guid id);
        Task<bool> AddAsync(KCT kct);
        Task<bool> UpdateAsync(Guid id, KCT kct);
        Task<bool> DeleteAsync(Guid id);
    }
}
