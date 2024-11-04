using Microsoft.EntityFrameworkCore;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;
using ProjectQLThueXe.Domain.Models;
using ProjectQLThueXe.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Infrastructure.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly MyDBContext _context;
        public ReceiptRepository(MyDBContext context)
        {
            _context = context;
        }
        public async Task<Receipts> AddAsync(ReceiptVM receiptVM)
        {
            if (receiptVM != null)
            {
                var _createReceipt_ID = Guid.NewGuid();
                double _totalMoney = 0;

                //get car by id
                var _carById = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == receiptVM.receiptDetails.Car_ID);
                if(_carById == null)
                {
                    return null!;
                }    
                //for (int i = 0;i < receiptVM.receiptDetails.Count; i++)
                //{
                    _totalMoney += _carById.Price * ((receiptVM.receiptDetails.TimeEnd - receiptVM.receiptDetails.TimeStart).Days);
                //}

                var _newReceipt = new Receipts
                {
                    Receipt_ID = _createReceipt_ID,
                    totalMoney = _totalMoney,
                    ReceiptTime = DateTime.Now,
                    KT_ID = receiptVM.KT_ID,
                    ReceiptStatus_ID = 2,
                    ReceiptDescription = receiptVM.ReceiptDescription,
                };
                var _addedReceipt = await _context.Receipts.AddAsync(_newReceipt);
                if(_addedReceipt != null)
                {
                    //for(int j = 0; j < receiptVM.receiptDetails.Count; j++)
                    //{
                        var _newReceiptDetail = new ReceiptDetail
                        {
                            ReceiptDetail_ID = Guid.NewGuid(),
                            Car_ID = receiptVM.receiptDetails.Car_ID,
                            Car_model = _carById.Model,
                            Car_Price = _carById.Price,
                            TimeStart = receiptVM.receiptDetails.TimeStart,
                            TimeEnd = receiptVM.receiptDetails.TimeEnd,
                            TotalDay = (receiptVM.receiptDetails.TimeEnd - receiptVM.receiptDetails.TimeStart).Days,
                            Receipt_ID = _createReceipt_ID
                        };
                        var addedReceiptDetail = await _context.ReceiptsDetail.AddAsync(_newReceiptDetail);
                    //}
                    //update status car
                    _carById.status = false;
                    await _context.SaveChangesAsync();

                    var _createdReceipt = await _context.Receipts.SingleOrDefaultAsync(e => e.Receipt_ID == _createReceipt_ID);
                    if (_createdReceipt != null)
                    {
                        return _createdReceipt;
                    }
                }    
            }
            return null!;
        }
        public Task<bool> UpdateAsync(Guid id, Receipts receipts)
        {
            throw new NotImplementedException();
        }


        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Receipts>> GetAllAsync()
        {
            return await _context.Receipts
                             .ToListAsync();
        }

        public async Task<Receipts> GetByIdAsync(Guid id)
        {
           if(!String.IsNullOrEmpty(id.ToString()))
            {
                var _receipt = await _context.Receipts.SingleOrDefaultAsync(e => e.Receipt_ID == id);
                if(_receipt != null)
                {
                    return _receipt;
                }
            }
            return null!;
        }
        //delete
        public async Task<Receipts> ConfirmRentCar(Guid id)
        {
            var _receiptById = await _context.Receipts.SingleOrDefaultAsync(e => e.Receipt_ID == id);
            if (_receiptById != null)
            {
                _receiptById.ReceiptStatus_ID = 2;
                var _receiptDetail = await _context.ReceiptsDetail.FirstOrDefaultAsync(e => e.Receipt_ID == id);
                if(_receiptDetail == null)
                {
                    return null!;
                }    
                var _carById = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == _receiptDetail.Car_ID);
                if(_carById == null)
                {
                    return null!;
                } 
                _carById.status = false;
                await _context.SaveChangesAsync();
                return _receiptById;
            }
            return null!;
        }
        //delete
        public async Task<Receipts> RejectRentcar(Guid id)
        {
            var _receiptById = await _context.Receipts.SingleOrDefaultAsync(e => e.Receipt_ID == id);
            if (_receiptById != null)
            {
                _receiptById.ReceiptStatus_ID = 3;
                var _receiptDetail = await _context.ReceiptsDetail.FirstOrDefaultAsync(e => e.Receipt_ID == id);
                if (_receiptDetail == null)
                {
                    return null!;
                }
                var _carById = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == _receiptDetail.Car_ID);
                if (_carById == null)
                {
                    return null!;
                }
                _carById.status = true;
                await _context.SaveChangesAsync();
                return _receiptById;
            }
            return null!;
        }

     
        //delete
        public async Task<Receipts> ConfirmReturnCar(Guid id)
        {
            var _receiptById = await _context.Receipts.SingleOrDefaultAsync(e => e.Receipt_ID == id);
            if (_receiptById != null)
            {
                _receiptById.ReceiptStatus_ID = 4;
                var _receiptDetail = await _context.ReceiptsDetail.FirstOrDefaultAsync(e => e.Receipt_ID == id);
                if (_receiptDetail == null)
                {
                    return null!;
                }
                var _carById = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == _receiptDetail.Car_ID);
                if (_carById == null)
                {
                    return null!;
                }
                _carById.status = true;
                await _context.SaveChangesAsync();
                return _receiptById;
            }
            return null!;
        }
    }
}
