using ProjectQLThueXe.Domain.DTOs;
using CarTypeVM = ProjectQLThueXe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectQLThueXe.Application.Mapping
{
    public class MapCarType
    {
        public static IEnumerable<CarTypeDTO> ListCarTypeToListCarTypeDTO(IEnumerable<CarTypeVM::CarType> listCarType)
        {
            try
            {
                if (listCarType != null)
                {
                    var _listCarTypeDTO = listCarType.Select(x => new CarTypeDTO
                    {
                        CarType_ID = x.CarType_ID,
                        CarTypeName = x.CarTypeName,
                    }).ToList();

                    return _listCarTypeDTO;
                }
                return null!;
            }
            catch
            {
                return null!;
            }
        }

        public static CarTypeDTO CarTypeToCarTypeDTO(CarTypeVM::CarType carType)
        {
            try
            {
                if (carType != null)
                {
                    var _carTypeDTO = new CarTypeDTO
                    {
                        CarType_ID = carType.CarType_ID,
                        CarTypeName = carType.CarTypeName,
                    };
                    return _carTypeDTO;
                }
                return null!;
            }catch
            {
                return null!;
            }
        }
    }
}
