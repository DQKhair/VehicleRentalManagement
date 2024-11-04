using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProjectQLThueXe.Application.Car.Commands;
using ProjectQLThueXe.Application.Car.Queries;
using ProjectQLThueXe.Application.CarType.Queries;
using ProjectQLThueXe.Application.KCT.Queries;
using ProjectQLThueXe.Application.KT.Queries;
using ProjectQLThueXe.Application.Mapping;
using ProjectQLThueXe.Domain.DTOs;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Models;
using System.Linq;
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

        /// <summary>
        /// Get all car
        /// </summary>
        /// <returns>Return list car with status code 200</returns>
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

        /// <summary>
        /// Get car by ID
        /// </summary>
        /// <param name="id">Car ID</param>
        /// <returns>Return car by ID with status code 200</returns>
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

        /// <summary>
        /// Update infomation Car
        /// </summary>
        /// <param name="id">Car ID</param>
        /// <param name="carVM"> other car information</param>
        /// <returns>Return updated car information with status code 200</returns>
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
                //Check if client has filled in the number plate old
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

        /// <summary>
        /// Add new car
        /// </summary>
        /// <param name="postCarVM">Infomation</param>
        /// <returns>Return added new car information with status code 201 </returns>
        [HttpPost]
        public async Task<ActionResult<Car>> AddNewCar([FromForm] PostCarVM postCarVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var _numberPlateExists = await _mediator.Send(new GetCarByNumberPlateQuery { NumberPlate = postCarVM.NumberPlate });
                if (_numberPlateExists != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "This number plate already exists." });
                }
                var _checkFile = ImageInvalid(postCarVM.Images);
                if (_checkFile != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = _checkFile });
                }
                var _created = await _mediator.Send(new CreateCarCommand
                {
                    Model = postCarVM.Model,
                    Price = postCarVM.Price,
                    NumberPlate = postCarVM.NumberPlate,
                    location = postCarVM.Location,
                    status = postCarVM.Status,
                    CarType_ID = postCarVM.CarType_ID,
                    KCT_ID = postCarVM.KCT_ID,
                    Image = postCarVM.Images,
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

        /// <summary>
        /// Delete car
        /// </summary>
        /// <param name="id">Car ID</param>
        /// <returns>Return status code 200 with message: Success</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(Guid id)
        {
            try
            {
                string _deleted = await _mediator.Send(new DeleteCarCommnad { Car_ID = id });
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

        /// <summary>
        /// Update location map car
        /// </summary>
        /// <param name="id">Car ID</param>
        /// <param name="location">Car address on the map</param>
        /// <returns>Return updated car infomation with status code 200</returns>
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

        /// <summary>
        /// Confirm return car
        /// </summary>
        /// <param name="id">Car ID</param>
        /// <param name="kt_ID">car renter </param>
        /// <returns>Return message: Return successful with status code 200</returns>
        [HttpPut("confirmReturn/{id}/{kt_ID}")]
        public async Task<IActionResult> ConfirmReturn(Guid id, Guid kt_ID)
        {
            try
            {
                var _ktById = await _mediator.Send(new GetKTByIdQuery { KT_ID = kt_ID });
                if(_ktById == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,new {message = "Customer not exists."});
                }
                var _carById = await _mediator.Send(new GetCarByIdQuery { Car_ID = id });
                if (_carById == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "Car not exists." });
                }
                var _returnCar = await _mediator.Send(new ReturnCarCommand { Car_ID= id, KT_ID = kt_ID });
                if(_returnCar != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Return successful!." });
                }   
                    return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Check image format
        /// </summary>
        /// <param name="file">File image</param>
        /// <returns>Return text error if the image is invalid</returns>
        private string ImageInvalid(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return "No file uploaded.";
            }

            //check size file (5MB)
            var maxFileSize = 5 * 1024 * 1024; // 5 MB
            if (file.Length > maxFileSize)
            {
                return "File size must not exceed 2 MB.";
            }

            // check file format
            var permittedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(extension) || !permittedExtensions.Contains(extension))
            {
                return "Only image files (.jpg, .jpeg, .png, .gif) are allowed.";
            }
            return null!;
        }
    }
}
