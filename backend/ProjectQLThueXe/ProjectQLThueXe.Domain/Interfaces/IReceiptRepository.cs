using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Domain.Interfaces
{
    public interface IReceiptRepository
    {
        Task<IEnumerable<Receipts>> GetAllAsync();
        Task<Receipts> GetByIdAsync(Guid id);
        Task<Receipts> AddAsync(ReceiptVM receiptVM);
        Task<bool> UpdateAsync(Guid id, Receipts receipts);
        Task<bool> DeleteAsync(Guid id);
        Task<Receipts> ConfirmRentCar(Guid id);
        Task<Receipts> RejectRentcar(Guid id);
        Task<Receipts> ConfirmReturnCar(Guid id);
    }
}
