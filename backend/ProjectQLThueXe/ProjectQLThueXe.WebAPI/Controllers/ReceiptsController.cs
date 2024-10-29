using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectQLThueXe.Application.Receipt.Commands;
using ProjectQLThueXe.Application.Receipt.Queries;
using ProjectQLThueXe.Domain.DTOs;
using ProjectQLThueXe.Domain.Entities;
using ProjectQLThueXe.Domain.Models;

namespace ProjectQLThueXe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ReceiptsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipts>>> GetAllReceipts()
        {
            try
            {
                var _receipts = await _mediator.Send(new GetAllReceiptQuery());
                return StatusCode(StatusCodes.Status200OK, _receipts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Receipts>> GetReceiptById(Guid id)
        {
            try
            {
                var _receipt = await _mediator.Send(new GetReceiptByIdQuery { Receipt_ID = id });
                if (_receipt == null)
                {
                    return NotFound();
                }
                return StatusCode(StatusCodes.Status200OK, _receipt);
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Receipts>> AddNewReceipt(ReceiptVM receiptVM)
        {
            try
            {
                var _created = await _mediator.Send(new CreateReceiptCommand
                {
                    KT_ID = receiptVM.KT_ID,
                    receiptDetails = receiptVM.receiptDetails,
                });
                if (_created != null)
                {
                    return CreatedAtAction("GetReceiptById", new { id = _created.Receipt_ID }, _created);
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
