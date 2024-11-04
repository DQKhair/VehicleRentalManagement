using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using ProjectQLThueXe.Application.KCT.Commands;
using ProjectQLThueXe.Application.KCT.Queries;
using ProjectQLThueXe.Domain.Models;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Application.KT.Queries;

namespace ProjectQLThueXe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KCTsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public KCTsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all car rental provider
        /// </summary>
        /// <returns>Return list car rental provider</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KCT>>> GetAllKCTs()
        {
            try
            {
                var _kct = await _mediator.Send(new GetAllKCTQuery());
                return StatusCode(StatusCodes.Status200OK, _kct);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Get car rental provider by ID
        /// </summary>
        /// <param name="id">car rental provider ID (KCT_ID)</param>
        /// <returns>Return car rental provider information with status code 200</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<KCT>> GetKCTById(Guid id)
        {
            try
            {
                var _kct = await _mediator.Send(new GetKCTByIdQuery { KCT_ID = id });
                if (_kct == null)
                {
                    return NotFound();
                }
                return StatusCode(StatusCodes.Status200OK,_kct);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Update car rental provider information
        /// </summary>
        /// <param name="id">car rental provider ID (KCT_ID)</param>
        /// <param name="kctVM">other infomation car rental provider</param>
        /// <returns>Return updated car rental provider infomation with status code 200</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKCT(Guid id, KCTVM kctVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var _kctById = await _mediator.Send(new GetKCTByIdQuery { KCT_ID = id });
                string oldCccd = _kctById.KCT_CCCD;
                string oldPhone = _kctById.KCT_Phone;
                if(oldCccd != kctVM.KCT_CCCD)
                {
                    var _cccdExists = await _mediator.Send(new GetKCTByCCCDQuery { KCT_CCCD = kctVM.KCT_CCCD });
                    if (_cccdExists != null)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new { message = "This CCCD already exists." });
                    }
                }
                if(oldPhone != kctVM.KCT_Phone)
                {
                    var _phoneExists = await _mediator.Send(new GetKCTByPhoneQuery { KCT_Phone = kctVM.KCT_Phone });
                    if (_phoneExists != null)
                    {
                        return StatusCode(StatusCodes.Status400BadRequest, new { message = "This Phone already exists." });
                    }
                }
               
                var _updated = await _mediator.Send(new UpdateKCTCommand
                {
                    KCT_ID = id,
                    KCT_Name = kctVM.KCT_Name,
                    KCT_Phone = kctVM.KCT_Phone,
                    KCT_Address = kctVM.KCT_Address,
                    KCT_CCCD = kctVM.KCT_CCCD,
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

        /// <summary>
        /// Add new car rental provider
        /// </summary>
        /// <param name="kctVM">Car rental provider infomation</param>
        /// <returns>Return added car rental provider information with status code 200</returns>
        [HttpPost]
        public async Task<ActionResult<KCT>> AddNewKCT(KCTVM kctVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var _cccdExists = await _mediator.Send(new GetKCTByCCCDQuery { KCT_CCCD = kctVM.KCT_CCCD });
                var _phoneExists = await _mediator.Send(new GetKCTByPhoneQuery { KCT_Phone = kctVM.KCT_Phone });
                if (_phoneExists != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "This Phone already exists." });
                }
                if (_cccdExists != null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "This CCCD already exists." });
                }
                var _created = await _mediator.Send(new CreateKCTCommand
                {
                    KCT_Name = kctVM.KCT_Name,
                    KCT_Phone = kctVM.KCT_Phone,
                    KCT_Address = kctVM.KCT_Address,
                    KCT_CCCD = kctVM.KCT_CCCD
                });
                if (_created != null)
                {
                    return CreatedAtAction("GetKCTById", new { id = _created.KCT_ID }, _created);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        /// <summary>
        /// Delete car rental provider by ID
        /// </summary>
        /// <param name="id">Car rental provider ID (KCT_ID)</param>
        /// <returns>Return message success with status code 200</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKCT(Guid id)
        {
            try
            {
                string _deleted = await _mediator.Send(new DeleteKCTCommand { KCT_ID = id });
                if(!string.IsNullOrEmpty(_deleted))
                {
                    return StatusCode(StatusCodes.Status200OK, _deleted);
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
