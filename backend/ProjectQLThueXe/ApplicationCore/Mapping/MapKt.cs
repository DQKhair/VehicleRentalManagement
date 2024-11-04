using ProjectQLThueXe.Domain.DTOs;
using Entity = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Mapping
{
    public class MapKt
    {
        public static IEnumerable<KTRentDTO> ListKtRentToListKTRentDTO(IEnumerable<Entity::Receipts> receipts, IEnumerable<Entity::ReceiptDetail> receiptDetails, IEnumerable<Entity::KT> kts, IEnumerable<Entity::ReceiptStatus> receiptStatuses)
        {
            try
            {
                var listKTRentDTO = receipts.Select(e => new KTRentDTO
                {

                    KT_ID = e.KT_ID,
                    KT_Name = kts.Where(x => x.KT_ID == e.KT_ID).Select(x => x.KT_Name).SingleOrDefault(),
                    KT_Phone = kts.Where(x => x.KT_ID == e.KT_ID).Select(x => x.KT_Phone).SingleOrDefault(),
                    KT_Address = kts.Where(x => x.KT_ID == e.KT_ID).Select(x => x.KT_Address).SingleOrDefault(),
                    KT_CCCD = kts.Where(x => x.KT_ID == e.KT_ID).Select(x => x.KT_CCCD).SingleOrDefault(),

                    Receipt_ID = e.Receipt_ID,
                    ReceiptStatusName = receiptStatuses.Where(x => x.ReceiptStatus_ID == e.ReceiptStatus_ID).Select(x => x.ReceiptstatusName).SingleOrDefault(),
                    ReceiptDetail = receiptDetails.Where(rd => rd.Receipt_ID == e.Receipt_ID).Select(rd => new ReceiptDetailDTO
                    {
                        ReceiptDetail_ID = rd.ReceiptDetail_ID,
                        Car_model = rd.Car_model,
                        Car_Price = rd.Car_Price,
                        TimeStart = rd.TimeStart,
                        TimeEnd = rd.TimeEnd,
                        TotalDay = rd.TotalDay,
                        Car_ID = rd.Car_ID,
                        Receipt_ID = rd.Receipt_ID,
                    }).FirstOrDefault()
                });
                if (listKTRentDTO != null)
                {
                    return listKTRentDTO;
                }
                return null!;
            }
            catch
            {
                return null!;
            }
        }

        public static KTRentDTO KtRentToKTRentDTO(Entity::Receipts receipts, IEnumerable<Entity::ReceiptDetail> receiptDetails, IEnumerable<Entity::KT> kts, IEnumerable<Entity::ReceiptStatus> receiptStatuses)
        {
            try
            {
                var ktRentDTO = new KTRentDTO
                {

                    KT_ID = receipts.KT_ID,
                    KT_Name = kts.Where(x => x.KT_ID == receipts.KT_ID).Select(x => x.KT_Name).SingleOrDefault(),
                    KT_Phone = kts.Where(x => x.KT_ID == receipts.KT_ID).Select(x => x.KT_Phone).SingleOrDefault(),
                    KT_Address = kts.Where(x => x.KT_ID == receipts.KT_ID).Select(x => x.KT_Address).SingleOrDefault(),
                    KT_CCCD = kts.Where(x => x.KT_ID == receipts.KT_ID).Select(x => x.KT_CCCD).SingleOrDefault(),

                    Receipt_ID = receipts.Receipt_ID,
                    ReceiptStatusName = receiptStatuses.Where(x => x.ReceiptStatus_ID == receipts.ReceiptStatus_ID).Select(x => x.ReceiptstatusName).SingleOrDefault(),
                    ReceiptDetail = receiptDetails.Where(rd => rd.Receipt_ID == receipts.Receipt_ID).Select(rd => new ReceiptDetailDTO
                    {
                        ReceiptDetail_ID = rd.ReceiptDetail_ID,
                        Car_model = rd.Car_model,
                        Car_Price = rd.Car_Price,
                        TimeStart = rd.TimeStart,
                        TimeEnd = rd.TimeEnd,
                        TotalDay = rd.TotalDay,
                        Car_ID = rd.Car_ID,
                        Receipt_ID = rd.Receipt_ID,
                    }).FirstOrDefault()
                };
                if (ktRentDTO != null)
                {
                    return ktRentDTO;
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
