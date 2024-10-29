using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectQLThueXe.Application.Car.Commands;
using ProjectQLThueXe.Application.Car.Queries;
using ProjectQLThueXe.Domain.DTOs;
using ProjectQLThueXe.Domain.Entities;

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
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            try
            {
                var _car = await _mediator.Send(new GetAllCarQuery());
                return StatusCode(StatusCodes.Status200OK, _car);
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
                if (_car == null)
                {
                    return NotFound();
                }
                return StatusCode(StatusCodes.Status200OK, _car);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(Guid id, CarDTO carDTO)
        {
            try
            {
                var _updated = await _mediator.Send(new UpdateCarCommand
                {
                    Car_ID = id,
                    Model = carDTO.Model,
                    Price = carDTO.Price,
                    Location = carDTO.Location,
                    Status = carDTO.Status,
                    CarType_ID = carDTO.CarType_ID,
                    KCT_ID = carDTO.KCT_ID,
                });
                if (_updated != null)
                {
                    return StatusCode(StatusCodes.Status200OK, _updated);
                }
                return StatusCode(StatusCodes.Status400BadRequest);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Car>> AddNewCar(CarDTO carDTO)
        {
            try
            {
                var _created = await _mediator.Send(new CreateCarCommand
                {
                    Model = carDTO.Model,
                    Price = carDTO.Price,
                    location = carDTO.Location,
                    status = carDTO.Status,
                    CarType_ID = carDTO.CarType_ID,
                    KCT_ID = carDTO.KCT_ID,
                });
                if (_created == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                return CreatedAtAction("GetCarById", new { id = carDTO.Car_ID }, carDTO);
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
    }
}
