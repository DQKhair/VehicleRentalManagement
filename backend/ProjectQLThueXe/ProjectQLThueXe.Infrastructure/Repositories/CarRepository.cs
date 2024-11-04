using Microsoft.EntityFrameworkCore;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Interfaces;
using ProjectQLThueXe.Domain.Models;
using ProjectQLThueXe.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly MyDBContext _context;
        public CarRepository(MyDBContext context)
        {
            _context = context;
        }
        public async Task<Car> AddAsync(PostCarVM postCarVM)
        {
            if(postCarVM != null )
            {
                if (postCarVM.Images != null)
                {
                    var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images");
                    if(!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    string _imgPath = Guid.NewGuid().ToString() + "_" + postCarVM.Images.FileName;
                    var _filePath = Path.Combine(folderPath, _imgPath);

                    using(var stream = new FileStream(_filePath,FileMode.Create))
                    {
                        await postCarVM.Images.CopyToAsync(stream);
                    }
                    string _imageFile = $"/Image/{_imgPath}";
                    var _car = new Car
                    {
                        Car_ID = Guid.NewGuid(),
                        Model = postCarVM.Model,
                        Price = postCarVM.Price,
                        NumberPlate = postCarVM.NumberPlate,
                        status = postCarVM.Status,
                        location = postCarVM.Location,
                        URLImage = _imageFile,
                        CarStatus_ID = 1,
                        CarType_ID = postCarVM.CarType_ID,
                        KCT_ID = postCarVM.KCT_ID,
                    };
                    if(_car != null)
                    {
                        await _context.Cars.AddAsync(_car);
                        await _context.SaveChangesAsync();
                        return _car;
                    }    
                }
            }
            return null!;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                var _car = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == id);
                if (_car != null)
                {
                    _context.Cars.Remove(_car);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            return false;
        }
        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetByIdAsync(Guid id)
        {
            if (!String.IsNullOrEmpty(id.ToString()))
            {
                //var _car = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == id);
                var _car = await _context.Cars.FindAsync(id);
                if(_car != null)
                {
                    return _car;
                }    
            }
            return null!;
        }

        public async Task<Car> GetByNumberPlate(string numberPlate)
        {
            if(string.IsNullOrEmpty(numberPlate))
            {
                return null!;
            }
            var _car = await _context.Cars.FirstOrDefaultAsync(e => e.NumberPlate == numberPlate);
            if (_car != null)
            { 
                return _car; 
            }
            return null!;
        }

        public async Task<bool> UpdateAsync(Guid id, Car car)
        {
            if (!String.IsNullOrEmpty(id.ToString()) && car != null)
            {
                var _car = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == id);
                if(_car != null)
                {
                    _car.Model = car.Model;
                    _car.Price = car.Price;
                    _car.NumberPlate = car.NumberPlate;
                    _car.location = car.location;
                    _car.status = car.status;
                    _car.CarType_ID = car.CarType_ID;
                    _car.KCT_ID = car.KCT_ID;

                    await _context.SaveChangesAsync();
                    return true;
                }    
            }
            return false;
        }

        public async Task<Car> UpdateLocationAsync(Guid id, string location)
        {
            if(String.IsNullOrEmpty(location))
            {
                return null!;
            }
            var _car = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == id);
            if (_car != null)
            {
                _car.location = location;
                await _context.SaveChangesAsync();
                var _updated = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == id);
                if (_updated != null)
                {
                    return _updated;
                }
            }
            return null!; ;
        }

        public async Task<Car> ReturnCarAsync(Guid id, Guid kt_ID)
        {
            if(!String.IsNullOrEmpty(id.ToString()))
            {
                var _result = await (from car in _context.Cars
                                        join receiptDetail in _context.ReceiptsDetail
                                            on car.Car_ID equals receiptDetail.Car_ID
                                        join receipt in _context.Receipts
                                            on receiptDetail.Receipt_ID equals receipt.Receipt_ID
                                            where car.Car_ID == id && receipt.KT_ID == kt_ID && receipt.ReceiptStatus_ID == 2
                                            select new {Car = car, Receipt = receipt, ReceiptDetail = receiptDetail}
                                            ).FirstOrDefaultAsync();
                if(_result != null)
                {
                    _result.Car.status = true;
                    _result.Receipt.ReceiptStatus_ID = 4;
                    await _context.SaveChangesAsync();

                    var _carById = await _context.Cars.SingleOrDefaultAsync(e => e.Car_ID == id);
                    if (_carById != null)
                    {
                        return _carById;
                    }
                }    
               
            }
            return null!;
        }
    }
}
