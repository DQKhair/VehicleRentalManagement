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

                for (int i = 0;i < receiptVM.receiptDetails.Count; i++)
                {
                    _totalMoney += receiptVM.receiptDetails[i].Car_Price * ((receiptVM.receiptDetails[i].TimeEnd - receiptVM.receiptDetails[i].TimeStart).Days);
                }

                var _newReceipt = new Receipts
                {
                    Receipt_ID = _createReceipt_ID,
                    totalMoney = _totalMoney,
                    ReceiptTime = DateTime.Now,
                    KT_ID = receiptVM.KT_ID,
                };
                var _addedReceipt = await _context.Receipts.AddAsync(_newReceipt);
                if(_addedReceipt != null)
                {
                    for(int j = 0; j < receiptVM.receiptDetails.Count; j++)
                    {
                        var _newReceiptDetail = new ReceiptDetail
                        {
                            ReceiptDetail_ID = Guid.NewGuid(),
                            Car_ID = receiptVM.receiptDetails[j].Car_ID,
                            Car_model = receiptVM.receiptDetails[j].Car_Model,
                            Car_Price = receiptVM.receiptDetails[j].Car_Price,
                            TimeStart = receiptVM.receiptDetails[j].TimeStart,
                            TimeEnd = receiptVM.receiptDetails[j].TimeEnd,
                            TotalDay = (receiptVM.receiptDetails[j].TimeEnd - receiptVM.receiptDetails[j].TimeStart).Days,
                            Receipt_ID = _createReceipt_ID
                        };
                        var addedReceiptDetail = await _context.ReceiptsDetail.AddAsync(_newReceiptDetail);
                    }   
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

        public Task<bool> UpdateAsync(Guid id, Receipts receipts)
        {
            throw new NotImplementedException();
        }
    }
}
