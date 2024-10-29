using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectQLThueXe.Application.CarType.Commands;
using ProjectQLThueXe.Application.CarType.Queries;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.DTOs;
using ProjectQLThueXe.Infrastructure.DBContext;

namespace ProjectQLThueXe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarType>>> GetALLCarTypes()
        {
            try
            {
                var carTypes = await _mediator.Send(new GetAllCarTypeQuery());
                return StatusCode(StatusCodes.Status200OK, carTypes);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarType>> GetCarTypeById(int id)
        {
            try
            {
                var _carType = await _mediator.Send(new GetCarTypeByIdQuery { CarType_ID = id });

                if (_carType == null)
                {
                    return NotFound();
                }

                return StatusCode(StatusCodes.Status200OK,_carType);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarType(int id, CarTypeDTO carTypeDTO)
        {
            try
            {
                string _updated = await _mediator.Send(new UpdateCarTypeCommand { CarType_ID = id, CarTypeName = carTypeDTO.CarTypeName });
                if (String.IsNullOrEmpty(_updated))
                {
                    return StatusCode(StatusCodes.Status200OK,_updated);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<CarType>> AddNewCarType(CarTypeDTO carTypeDTO)
        {
            try
            {
                string _created = await _mediator.Send(new CreateCarTypeCommand { CarTypeName = carTypeDTO.CarTypeName });
                if(String.IsNullOrEmpty(_created))
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }  
                
                return CreatedAtAction("GetCarTypeById", new { id = carTypeDTO.CarType_ID }, carTypeDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarType(int id)
        {
            try
            {
                string _deleted = await _mediator.Send(new DeleteCarTypeCommand { CarType_ID = id });
                if(String.IsNullOrEmpty(_deleted))
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                return StatusCode(StatusCodes.Status200OK, _deleted);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
