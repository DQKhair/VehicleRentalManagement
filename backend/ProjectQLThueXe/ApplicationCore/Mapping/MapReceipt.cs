using ProjectQLThueXe.Domain.DTOs;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Mapping
{
    public class MapReceipt
    {
        public static IEnumerable<ReceiptDTO> ListReceiptToListReceiptDTO(IEnumerable<Entity::Receipts> receipts, IEnumerable<Entity::ReceiptDetail> receiptDetails, IEnumerable<Entity::KT> kts)
        {
            try
            {
                var listReceiptDTO = receipts.Select(e => new ReceiptDTO
                {
                    Receipt_ID = e.Receipt_ID,
                    TotalMoney = e.totalMoney,
                    ReceiptTime = e.ReceiptTime,
                    KT_ID = e.KT_ID,
                    KT_Name = kts.Where(x => x.KT_ID == e.KT_ID).Select(x => x.KT_Name).SingleOrDefault(),
                    ReceiptDetailDTOs = receiptDetails.Where(rd => rd.Receipt_ID == e.Receipt_ID).Select(rd => new ReceiptDetailDTO
                    {
                        ReceiptDetail_ID = rd.ReceiptDetail_ID,
                        Car_model = rd.Car_model,
                        Car_Price = rd.Car_Price,
                        TimeStart = rd.TimeStart,
                        TimeEnd = rd.TimeEnd,
                        TotalDay = rd.TotalDay,
                        Car_ID = rd.Car_ID,
                        Receipt_ID = rd.Receipt_ID,
                    }).ToList()
                });
                if (listReceiptDTO != null)
                {
                    return listReceiptDTO;
                }
                return null!;
            }catch
            {
                return null!;
            }
        }

        public static ReceiptDTO ReceiptToReceiptDTO(Entity::Receipts receipt, IEnumerable<Entity::ReceiptDetail> receiptDetails, IEnumerable<Entity::KT> kts)
        {
            try
            {
                var _receiptDTO = new ReceiptDTO
                {
                    Receipt_ID = receipt.Receipt_ID,
                    TotalMoney = receipt.totalMoney,
                    ReceiptTime = receipt.ReceiptTime,
                    KT_ID = receipt.KT_ID,
                    KT_Name = kts.Where(x => x.KT_ID == receipt.KT_ID).Select(x => x.KT_Name).SingleOrDefault(),
                    ReceiptDetailDTOs = receiptDetails.Where(rd => rd.Receipt_ID == receipt.Receipt_ID).Select(rd => new ReceiptDetailDTO
                    {
                        ReceiptDetail_ID = rd.ReceiptDetail_ID,
                        Car_model = rd.Car_model,
                        Car_Price = rd.Car_Price,
                        TimeStart = rd.TimeStart,
                        TimeEnd = rd.TimeEnd,
                        TotalDay = rd.TotalDay,
                        Car_ID = rd.Car_ID,
                        Receipt_ID = rd.Receipt_ID,
                    }).ToList()
                };
                if (_receiptDTO != null)
                {
                    return _receiptDTO;
                }
                return null!;
            }
            catch
            {
                return null!;
            }
        }
    }
}
