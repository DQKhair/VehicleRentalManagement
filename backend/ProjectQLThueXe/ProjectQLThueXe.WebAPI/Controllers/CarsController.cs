using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectQLThueXe.Application.Car.Commands;
using ProjectQLThueXe.Application.Car.Queries;
using ProjectQLThueXe.Application.CarType.Queries;
using ProjectQLThueXe.Application.KCT.Queries;
using ProjectQLThueXe.Application.Mapping;
using ProjectQLThueXe.Domain.DTOs;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ProjectQLThueXe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarDTO>>> GetCars()
        {
            try
            {
                var _cars = await _mediator.Send(new GetAllCarQuery());
                var _kcts = await _mediator.Send(new GetAllKCTQuery());
                var _carTypes = await _mediator.Send(new GetAllCarTypeQuery());
                if(_cars != null && _kcts != null && _carTypes != null)
                {
                   var _carDTOs = MapCar.ListCarToListCarDTO(_cars, _carTypes, _kcts);
                    if (_carDTOs != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, _carDTOs);
                    }
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(Guid id)
        {
            try
            {
                var _car = await _mediator.Send(new GetCarByIdQuery { Car_ID = id });
                var _kcts = await _mediator.Send(new GetAllKCTQuery());
                var _carTypes = await _mediator.Send(new GetAllCarTypeQuery());
                if (_car == null)
                {
                    return NotFound();
                }
                if(_car != null && _kcts != null && _carTypes != null)
                {
                    var _carDTO = MapCar.CarToCarDTO(_car,_carTypes, _kcts);
                    if(_carDTO != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, _carDTO);
                    }    
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CarDTO>> UpdateCar(Guid id, CarVM carVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var _carById = await _mediator.Send(new GetCarByIdQuery { Car_ID = id });
                string oldNumPlate = _carById.NumberPlate;
                if(oldNumPlate != carVM.NumberPlate)
                {
                    var _numberPlateExists = await _mediator.Send(new GetCarByNumberPlateQuery { NumberPlate = carVM.NumberPlate });
                    if (_numberPlateExists != null)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new { message = "This number plate already exists." });
                    }
                }    
                var _updated = await _mediator.Send(new UpdateCarCommand
                {
                    Car_ID = id,
                    Model = carVM.Model,
                    Price = carVM.Price,
                    NumberPlate = carVM.NumberPlate,
                    Location = carVM.Location,
                    Status = carVM.Status,
                    CarType_ID = carVM.CarType_ID,
                    KCT_ID = carVM.KCT_ID,
                });
                if (_updated != null)
                {
                    var _kcts = await _mediator.Send(new GetAllKCTQuery());
                    var _carTypes = await _mediator.Send(new GetAllCarTypeQuery());
                    var _carDTO = MapCar.CarToCarDTO(_updated, _carTypes, _kcts);
                    if(_carDTO != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, _carDTO);
                    }    
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Car>> AddNewCar(CarVM carVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var _numberPlateExists = await _mediator.Send(new GetCarByNumberPlateQuery { NumberPlate = carVM.NumberPlate });
                if (_numberPlateExists != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "This number plate already exists." });
                }
                var _created = await _mediator.Send(new CreateCarCommand
                {
                    Model = carVM.Model,
                    Price = carVM.Price,
                    NumberPlate = carVM.NumberPlate,
                    location = carVM.Location,
                    status = carVM.Status,
                    CarType_ID = carVM.CarType_ID,
                    KCT_ID = carVM.KCT_ID,
                });
                if (_created != null)
                {
                    var _kcts = await _mediator.Send(new GetAllKCTQuery());
                    var _carTypes = await _mediator.Send(new GetAllCarTypeQuery());
                    var _carDTO = MapCar.CarToCarDTO(_created, _carTypes, _kcts);
                    if(_carDTO != null)
                    {
                        return CreatedAtAction("GetCarById", new { id = _carDTO.Car_ID }, _carDTO);
                    }    
                }
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            try
            {
                var _deleted = await _mediator.Send(new DeleteCarCommnad { Car_ID = id });
                if(!String.IsNullOrEmpty(_deleted))
                {
                    return StatusCode(StatusCodes.Status200OK);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }

        }

        [HttpPut("update_location/{id}")]
        public async Task<ActionResult<CarDTO>> UpdateLocationCar(Guid id, string location)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var _updated = await _mediator.Send(new UpdateLocationCarCommand
                {
                    Car_ID = id,
                    Location = location
                });
                var _carType = await _mediator.Send(new GetAllCarTypeQuery());
                var _kct = await _mediator.Send(new GetAllKCTQuery());

                var _carDTO = MapCar.CarToCarDTO(_updated,_carType,_kct);
                if(_carDTO != null)
                {
                    return StatusCode(StatusCodes.Status200OK,_carDTO);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}
