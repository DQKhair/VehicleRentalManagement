﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectQLThueXe.Application.KT.Commands;
using ProjectQLThueXe.Application.KT.Queries;
using ProjectQLThueXe.Domain.DTOs;
using ProjectQLThueXe.Domain.Entities;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateKt(Guid id, KTDTO kt)
        {
            try
            {
                var _updated = await _mediator.Send(new UpdateKTCommand
                { 
                    KT_ID = id,
                    KT_Name = kt.KT_Name,
                    KT_Phone = kt.KT_Phone,
                    KT_Address = kt.KT_Address,
                    KT_CCCD = kt.KT_CCCD,
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

        [HttpPost]
        public async Task<ActionResult<KT>> AddNewKT(KTDTO ktDTO)
        {
            try
            {
                var _created = await _mediator.Send(new CreateKTCommand 
                {
                    KT_Name = ktDTO.KT_Name,
                    KT_Phone = ktDTO.KT_Phone,
                    KT_Address = ktDTO.KT_Address,
                    KT_CCCD = ktDTO.KT_CCCD,
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKT(Guid id)
        {
            try
            {
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
    }
}
