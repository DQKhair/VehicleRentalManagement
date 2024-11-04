using ProjectQLThueXe.Domain.DTOs;
using Entity = ProjectQLThueXe.Domain.Entities;

namespace ProjectQLThueXe.Application.Mapping
{
    public class MapCar
    {
        public static IEnumerable<CarDTO> ListCarToListCarDTO(IEnumerable<Entity::Car> cars, IEnumerable<Entity::CarType> cartypes, IEnumerable<Entity::KCT> kcts)
        {
            try
            {
                if (cars != null && cartypes != null && kcts != null)
                {
                    var listCarDTO = cars.Select(e => new CarDTO
                    {
                        Car_ID = e.Car_ID,
                        Model = e.Model,
                        NumberPlate = e.NumberPlate,
                        Price = e.Price,
                        Location = e.location,
                        Status = e.status,
                        URLImage = e.URLImage,
                        CarType_ID = e.CarType_ID,
                        CarTypeName = cartypes.Where(x => x.CarType_ID == e.CarType_ID).Select(e => e.CarTypeName).SingleOrDefault(),
                        KCT_ID = e.KCT_ID,
                        KCT_Name = kcts.Where(x => x.KCT_ID == e.KCT_ID).Select(x => x.KCT_Name).SingleOrDefault(),
                    }
                    );
                    return listCarDTO;
                }
                return null!;
            }
            catch
            {
                return null!;
            }
        }

        public static CarDTO CarToCarDTO(Entity::Car car, IEnumerable<Entity::CarType> cartypes, IEnumerable<Entity::KCT> kcts)
        {
            try
            {
                var carDTO = new CarDTO
                {
                    Car_ID = car.Car_ID,
                    Model = car.Model,
                    NumberPlate = car.NumberPlate,
                    Price = car.Price,
                    Location = car.location,
                    Status = car.status,
                    URLImage = car.URLImage,
                    CarType_ID = car.CarType_ID,
                    CarTypeName = cartypes.Where(x => x.CarType_ID == car.CarType_ID).Select(e => e.CarTypeName).SingleOrDefault(),
                    KCT_ID = car.KCT_ID,
                    KCT_Name = kcts.Where(x => x.KCT_ID == car.KCT_ID).Select(x => x.KCT_Name).SingleOrDefault(),
                };
                if (carDTO != null)
                {
                    return carDTO;
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
