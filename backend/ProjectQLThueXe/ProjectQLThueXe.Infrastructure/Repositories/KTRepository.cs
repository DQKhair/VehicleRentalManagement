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
    public class KTRepository : IKTRepository
    {
        private readonly MyDBContext _Context;
        public KTRepository(MyDBContext context)
        {
            _Context = context;
        }
        public async Task<bool> AddAsync(KT kt)
        {
            if( kt == null)
            {
                return false;
            }
            await _Context.KTs.AddAsync(kt);
            await _Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                var _kt = await _Context.KTs.SingleOrDefaultAsync(e => e.KT_ID == id);
                if (_kt != null)
                {
                    _Context.KTs.Remove(_kt);
                    await _Context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }


        public async Task<IEnumerable<KT>> GetAllAsync()
        {
            return await _Context.KTs.ToListAsync();
        }

        public async Task<KT> GetByIdAsync(Guid id)
        {
            if(!String.IsNullOrEmpty(id.ToString()))
            {
                var _kt = await _Context.KTs.SingleOrDefaultAsync(e => e.KT_ID == id);
                if(_kt != null)
                {
                    return _kt;
                }
            }
            return null!;
        }
        public async Task<KT> GetByCCCDAsync(string cccd)
        {
            if(!String.IsNullOrEmpty(cccd))
            {
                var _kt = await _Context.KTs.FirstOrDefaultAsync(e => e.KT_CCCD == cccd);
                if (_kt != null)
                {
                   return _kt;
                }
            }
            return null!;
        }

        public async Task<KT> GetByPhoneAsync(string phone)
        {
            if(!String.IsNullOrEmpty(phone))
            {
                var _kt = await _Context.KTs.FirstOrDefaultAsync(e => e.KT_Phone == phone);
                if(_kt != null)
                {
                    return _kt;
                }
            }
            return null!;
        }

        public async Task<bool> UpdateAsync(Guid id, KT kt)
        {
            if (!String.IsNullOrEmpty(id.ToString()) && kt != null)
            {
                var _kt = await _Context.KTs.SingleOrDefaultAsync(e => e.KT_ID == id);
                if(_kt != null)
                {
                    _kt.KT_Name = kt.KT_Name;
                    _kt.KT_Phone = kt.KT_Phone;
                    _kt.KT_Address = kt.KT_Address;
                    _kt.KT_CCCD = kt.KT_CCCD;

                    await _Context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }

       

        public async Task<bool> CancelRentCar(Guid Car_ID, Guid kt_ID)
        {
            var _receiptCancel = await (from receipt in _Context.Receipts
                                        join receiptDetail in _Context.ReceiptsDetail
                                            on receipt.Receipt_ID equals receiptDetail.Receipt_ID
                                        join car in _Context.Cars
                                            on receiptDetail.Car_ID equals car.Car_ID
                                        where receipt.KT_ID == kt_ID && receiptDetail.Car_ID == Car_ID && (receipt.ReceiptStatus_ID == 1 || receipt.ReceiptStatus_ID == 2)
                                        select new
                                        {
                                            Receipt = receipt,
                                            ReceiptDetail = receiptDetail,
                                            Car = car
                                        }).FirstOrDefaultAsync();
            if(_receiptCancel != null)
            {
                if( _receiptCancel.ReceiptDetail.TimeStart > DateTime.Now)
                {
                    _receiptCancel.Receipt.ReceiptStatus_ID = 3;
                    _receiptCancel.Car.status = true;
                    await _Context.SaveChangesAsync();
                    return true;
                }
            }    
            return false;
        }
    }
}
