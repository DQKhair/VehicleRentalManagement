using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectQLThueXe.Application.KT.Commands;
using ProjectQLThueXe.Application.KT.Queries;
using ProjectQLThueXe.Domain.Models;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Application.KCT.Queries;
using ProjectQLThueXe.Domain.DTOs;
using ProjectQLThueXe.Application.Receipt.Queries;
using ProjectQLThueXe.Application.ReceiptDetail.Queries;
using ProjectQLThueXe.Application.Mapping;
using ProjectQLThueXe.Application.ReceiptStatus.Queries;
using BCr = BCrypt.Net.BCrypt;

namespace ProjectQLThueXe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KtsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public KtsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all car renter
        /// </summary>
        /// <returns>Return list car renter</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KT>>> GetAllKTs()
        {
            try
            {
                var _kt = await _mediator.Send(new GetAllKTQuery());
                return StatusCode(StatusCodes.Status200OK, _kt);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        /// <summary>
        /// Get car renter by ID
        /// </summary>
        /// <param name="id">car renter ID (KT_ID)</param>
        /// <returns>Return car renter information with status code 200</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<KT>> GetKTById(Guid id)
        {
            try
            {
                var _kt = await _mediator.Send(new GetKTByIdQuery { KT_ID = id });
                if (_kt == null)
                {
                    return NotFound();
                }
                return StatusCode(StatusCodes.Status200OK, _kt);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Update car renter information
        /// </summary>
        /// <param name="id">car renter ID (KT_ID)</param>
        /// <param name="ktVM">other car renter information</param>
        /// <returns>Return updated car renter information with status code 200</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKt(Guid id, KTVM ktVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var _ktById = await _mediator.Send(new GetKTByIdQuery { KT_ID = id });
                string oldCCCD = _ktById.KT_CCCD;
                string oldPhone = _ktById.KT_Phone;
                if(oldCCCD != ktVM.KT_CCCD)
                {
                    var _cccdExists = await _mediator.Send(new GetKTByCCCDQuery { KT_CCCD = ktVM.KT_CCCD });
                    if (_cccdExists != null)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new { message = "This CCCD already exists." });
                    }
                }
                if(oldPhone != ktVM.KT_Phone)
                {
                    var _phoneExists = await _mediator.Send(new GetKTByPhoneQuery { KT_Phone = ktVM.KT_Phone });
                    if (_phoneExists != null)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new { message = "This Phone already exists." });
                    }
                }
                var _updated = await _mediator.Send(new UpdateKTCommand
                { 
                    KT_ID = id,
                    KT_Name = ktVM.KT_Name,
                    KT_Phone = ktVM.KT_Phone,
                    KT_Address = ktVM.KT_Address,
                    KT_CCCD = ktVM.KT_CCCD,
                }); 
                if (_updated == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                return StatusCode(StatusCodes.Status200OK,_updated);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Add new car renter
        /// </summary>
        /// <param name="ktVM">car renter information</param>
        /// <returns>Return added car renter information with status code 201</returns>
        [HttpPost]
        public async Task<ActionResult<KT>> AddNewKT(KTVM ktVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var _cccdExists = await _mediator.Send(new GetKTByCCCDQuery { KT_CCCD = ktVM.KT_CCCD });
                var _phoneExists = await _mediator.Send(new GetKTByPhoneQuery { KT_Phone = ktVM.KT_Phone });
                if (_phoneExists != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "This Phone already exists." });
                }
                if (_cccdExists != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "This CCCD already exists." });
                }
                var _created = await _mediator.Send(new CreateKTCommand 
                {
                    KT_Name = ktVM.KT_Name,
                    KT_Phone = ktVM.KT_Phone,
                    KT_Address = ktVM.KT_Address,
                    KT_CCCD = ktVM.KT_CCCD,
                    KT_Password = ConvertPasswordToHash(ktVM.KT_Password)
                });
                if (_created != null)
                {
                    return CreatedAtAction("GetKTById", new { id = _created.KT_ID }, _created);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        /// <summary>
        /// Delete car renter
        /// </summary>
        /// <param name="id">Car renter ID (KT_ID)</param>
        /// <returns>Return message success with status code 200</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKT(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                string _deleted = await _mediator.Send(new DeleteKTCommand { KT_ID = id });
                if(String.IsNullOrEmpty(_deleted))
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }
                return StatusCode(StatusCodes.Status200OK, _deleted);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Cencel rent car
        /// </summary>
        /// <param name="car_ID">Car ID (Car_ID)</param>
        /// <param name="kt_ID">car renter ID (KT_ID)</param>
        /// <returns>Return message success with status code 200</returns>
        [HttpPut("cancelRentCar/{car_ID}/{kt_ID}")]
        public async Task<IActionResult> CancelRentCar(Guid car_ID, Guid kt_ID)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (car_ID == Guid.Empty || kt_ID == Guid.Empty)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "Invalid parameters" });
                }

                var _result = await _mediator.Send(new CancelRentCarCommand { Car_ID = car_ID, KT_ID = kt_ID });

                if (_result != null)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = _result });
                }

                return StatusCode(StatusCodes.Status400BadRequest, new { message = "Failed to cancel" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Hash password
        /// </summary>
        /// <param name="password">Car renter password</param>
        /// <returns>Return hash password</returns>
        private string ConvertPasswordToHash(string password)
        {
            string salt = BCr.GenerateSalt(12);

            return BCr.HashPassword(password, salt);
        }
    }
}
