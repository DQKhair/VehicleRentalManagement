using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectQLThueXe.Application.KT.Queries;
using ProjectQLThueXe.Application.Mapping;
using ProjectQLThueXe.Application.Receipt.Commands;
using ProjectQLThueXe.Application.Receipt.Queries;
using ProjectQLThueXe.Application.ReceiptDetail.Queries;
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
        public async Task<ActionResult<IEnumerable<ReceiptDTO>>> GetAllReceipts()
        {
            try
            {
                var _receipts = await _mediator.Send(new GetAllReceiptQuery());
                var _receiptDetails = await _mediator.Send(new GetAllReceiptDetailQuery());
                var _kts = await _mediator.Send(new GetAllKTQuery());
                var _receiptDTO = MapReceipt.ListReceiptToListReceiptDTO(_receipts, _receiptDetails, _kts);
                if (_receiptDTO != null)
                {
                    return StatusCode(StatusCodes.Status200OK, _receiptDTO);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReceiptDTO>> GetReceiptById(Guid id)
        {
            try
            {
                var _receipt = await _mediator.Send(new GetReceiptByIdQuery { Receipt_ID = id });
                var _receiptDetails = await _mediator.Send(new GetAllReceiptDetailQuery());
                var _kts = await _mediator.Send(new GetAllKTQuery());
                var _receiptDTO = MapReceipt.ReceiptToReceiptDTO(_receipt, _receiptDetails, _kts);
                if (_receipt == null)
                {
                    return NotFound();
                }
                if(_receiptDTO != null)
                {
                    return StatusCode(StatusCodes.Status200OK, _receiptDTO);
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
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
                    var _receiptDetails = await _mediator.Send(new GetAllReceiptDetailQuery());
                    var _kts = await _mediator.Send(new GetAllKTQuery());
                    var _receiptDTO = MapReceipt.ReceiptToReceiptDTO(_created, _receiptDetails, _kts);
                    if(_receiptDTO != null)
                    {
                        return CreatedAtAction("GetReceiptById", new { id = _receiptDTO.Receipt_ID }, _receiptDTO);
                    }    
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
