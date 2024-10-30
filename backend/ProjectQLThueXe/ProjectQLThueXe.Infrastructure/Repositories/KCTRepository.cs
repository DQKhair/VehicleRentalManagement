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
    public class KCTRepository : IKCTRepository
    {
        private readonly MyDBContext _Context;

        public KCTRepository(MyDBContext context)
        {
            _Context = context;
        }
        public async Task<bool> AddAsync(KCT kct)
        {
                if (kct == null)
                {
                    return false;
                }
                await _Context.KCTs.AddAsync(kct);
                await _Context.SaveChangesAsync();
                return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if(!String.IsNullOrEmpty(id.ToString()))
            {
                var _kct = await _Context.KCTs.SingleOrDefaultAsync(e => e.KCT_ID == id);
                if(_kct != null)
                {
                    _Context.KCTs.Remove(_kct);
                    await _Context.SaveChangesAsync();
                    return true;
                }    
            }    
            return false;
        }

        public async Task<IEnumerable<KCT>> GetAllAsync()
        {
            return await _Context.KCTs.ToListAsync();
        }

        public async Task<KCT> GetByIdAsync(Guid id)
        {
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                var _kct = await _Context.KCTs.SingleOrDefaultAsync(e => e.KCT_ID == id);
                if(_kct != null)
                {
                    return _kct;
                }    
            }
            return null!;
        }
        public async Task<KCT> GetByCCCDAsync(string CCCD)
        {
            if(!String.IsNullOrEmpty(CCCD))
            {
                var _kct = await _Context.KCTs.FirstOrDefaultAsync(e => e.KCT_CCCD == CCCD);
                if(_kct != null)
                {
                    return _kct;
                }
            }
            return null!;
        }

        public async Task<KCT> GetByPhoneAsync(string Phone)
        {
            if(!String.IsNullOrEmpty(Phone))
            {
                var _kct = await _Context.KCTs.FirstOrDefaultAsync(e => e.KCT_Phone == Phone);
                if(_kct != null)
                {
                    return _kct;
                }
            }
            return null!;
        }

        public async Task<bool> UpdateAsync(Guid id, KCT kct)
        {
           if(!String.IsNullOrEmpty(id.ToString()) && kct != null)
           {
                var _kct = await _Context.KCTs.SingleOrDefaultAsync(e => e.KCT_ID == id);
                if (_kct != null)
                {
                    _kct.KCT_Name = kct.KCT_Name;
                    _kct.KCT_Phone = kct.KCT_Phone;
                    _kct.KCT_address = kct.KCT_address;
                    _kct.KCT_CCCD = kct.KCT_CCCD;

                    await _Context.SaveChangesAsync();
                    return true;
                }
           }    
           return false;
        }
    }
}
