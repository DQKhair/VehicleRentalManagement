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
using ProjectQLThueXe.Domain.Models;
using ProjectQLThueXe.Application.Mapping;
using FluentValidation;

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

        /// <summary>
        /// Get all car type
        /// </summary>
        /// <returns>Return list car type with status code 200</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarTypeDTO>>> GetALLCarTypes()
        {
            try
            {
                var carTypes = await _mediator.Send(new GetAllCarTypeQuery());
                var _carTypeDTO = MapCarType.ListCarTypeToListCarTypeDTO(carTypes);
                if (_carTypeDTO != null)
                {
                    return StatusCode(StatusCodes.Status200OK, _carTypeDTO);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
            
        }

        /// <summary>
        /// Get car type by ID
        /// </summary>
        /// <param name="id">Car type ID</param>
        /// <returns>Return car type by ID with status code 200</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CarType>> GetCarTypeById(int id)
        {
            try
            {
                var _carType = await _mediator.Send(new GetCarTypeByIdQuery { CarType_ID = id });

                var _carTypeDTO = MapCarType.CarTypeToCarTypeDTO(_carType);

                if (_carType != null && _carTypeDTO != null)
                {
                    return StatusCode(StatusCodes.Status200OK, _carTypeDTO);
                }
                return NotFound();

            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,ex);
            }
        }

        /// <summary>
        /// Update car type name
        /// </summary>
        /// <param name="id">Car type ID</param>
        /// <param name="carTypeVM">Car type name</param>
        /// <returns>Return updated car type information</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCarType(int id, CarTypeVM carTypeVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var _carTypeExist = await _mediator.Send(new GetCarTypeByNameQuery { CarTypeName = carTypeVM.CarTypeName });
                if (_carTypeExist != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "This name already exists." });
                }

                string _updated = await _mediator.Send(new UpdateCarTypeCommand { CarType_ID = id, CarTypeName = carTypeVM.CarTypeName });
                if (!String.IsNullOrEmpty(_updated))
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

        /// <summary>
        /// Add new car type
        /// </summary>
        /// <param name="carTypeVM">New car type name</param>
        /// <returns>Return car type with status code 201</returns>
        [HttpPost]
        public async Task<ActionResult<CarType>> AddNewCarType(CarTypeVM carTypeVM)
        {
            try
            {
                var _carTypeExist = await _mediator.Send(new GetCarTypeByNameQuery { CarTypeName = carTypeVM.CarTypeName });
                if(_carTypeExist != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "This name already exists." });
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                string _created = await _mediator.Send(new CreateCarTypeCommand { CarTypeName = carTypeVM.CarTypeName });

                if(String.IsNullOrEmpty(_created))
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }  
                return StatusCode(StatusCodes.Status200OK, carTypeVM);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Delete car type by ID
        /// </summary>
        /// <param name="id">Car type ID</param>
        /// <returns>Return message success with status code 200</returns>
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
