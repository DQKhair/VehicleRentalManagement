using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using ProjectQLThueXe.Application.KCT.Commands;
using ProjectQLThueXe.Application.KCT.Queries;
using ProjectQLThueXe.Domain.DTOs;
using ProjectQLThueXe.Domain.Entities;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKCT(Guid id, KCTDTO kctDTO)
        {
            try
            {
                var _updated = await _mediator.Send(new UpdateKCTCommand
                {
                    KCT_ID = id,
                    KCT_Name = kctDTO.KCT_Name,
                    KCT_Phone = kctDTO.KCT_Phone,
                    KCT_Address = kctDTO.KCT_Address,
                    KCT_CCCD = kctDTO.KCT_CCCD,
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
        public async Task<ActionResult<KCT>> AddNewKCT(KCTDTO kctDTO)
        {
            try
            {
                var _created = await _mediator.Send(new CreateKCTCommand
                {
                    KCT_Name = kctDTO.KCT_Name,
                    KCT_Phone = kctDTO.KCT_Phone,
                    KCT_Address = kctDTO.KCT_Address,
                    KCT_CCCD = kctDTO.KCT_CCCD
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
