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
        Task<KCT> GetByCCCDAsync(string CCCD);
        Task<KCT> GetByPhoneAsync(string Phone);
        Task<bool> AddAsync(KCT kct);
        Task<bool> UpdateAsync(Guid id, KCT kct);
        Task<bool> DeleteAsync(Guid id);
    }
}
