using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectQLThueXe.Application.Car.Queries;
using ProjectQLThueXe.Application.KT.Queries;
using ProjectQLThueXe.Application.Mapping;
using ProjectQLThueXe.Application.Receipt.Commands;
using ProjectQLThueXe.Application.Receipt.Queries;
using ProjectQLThueXe.Application.ReceiptDetail.Queries;
using ProjectQLThueXe.Application.ReceiptStatus.Queries;
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

        /// <summary>
        /// Get all receipt 
        /// </summary>
        /// <returns>Return list receipt with status code 200</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceiptDTO>>> GetAllReceipts()
        {
            try
            {
                var _receipts = await _mediator.Send(new GetAllReceiptQuery());
                var _receiptDetails = await _mediator.Send(new GetAllReceiptDetailQuery());
                var _kts = await _mediator.Send(new GetAllKTQuery());
                var _receiptStatus = await _mediator.Send(new GetAllReceiptStatusQuery());
                var _receiptDTO = MapReceipt.ListReceiptToListReceiptDTO(_receipts, _receiptDetails, _kts, _receiptStatus);
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

        /// <summary>
        /// Get receipt by ID
        /// </summary>
        /// <param name="id">Receipt ID (Receipt_ID)</param>
        /// <returns>Return receipt infomation with status code 200</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceiptDTO>> GetReceiptById(Guid id)
        {
            try
            {
                var _receipt = await _mediator.Send(new GetReceiptByIdQuery { Receipt_ID = id });
                var _receiptDetails = await _mediator.Send(new GetAllReceiptDetailQuery());
                var _kts = await _mediator.Send(new GetAllKTQuery());
                var _receiptStatus = await _mediator.Send(new GetAllReceiptStatusQuery());

                var _receiptDTO = MapReceipt.ReceiptToReceiptDTO(_receipt, _receiptDetails, _kts, _receiptStatus);
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

        /// <summary>
        /// Add new receipt
        /// </summary>
        /// <param name="receiptVM">receipt information</param>
        /// <returns>Return added receipt information with status code 201</returns>
        [HttpPost]
        public async Task<ActionResult<Receipts>> AddNewReceipt(ReceiptVM receiptVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var currentDay = DateTime.Now;
                if(currentDay > receiptVM.receiptDetails.TimeStart)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "Day invalid." });
                }    
                if(receiptVM.receiptDetails.TimeStart > receiptVM.receiptDetails.TimeEnd )
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "Day invalid." });
                }
                var _carById = await _mediator.Send(new GetCarByIdQuery { Car_ID = receiptVM.receiptDetails.Car_ID });
                if( _carById == null )
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "Car not exists." });
                }    
                if(_carById.status == false)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new { message = "The car has been rented. " });
                }    
                var _created = await _mediator.Send(new CreateReceiptCommand
                {
                    KT_ID = receiptVM.KT_ID,
                    ReceiptDescription = receiptVM.ReceiptDescription,
                    receiptDetails = receiptVM.receiptDetails,
                });
                if (_created != null)
                {
                    var _receiptDetails = await _mediator.Send(new GetAllReceiptDetailQuery());
                    var _kts = await _mediator.Send(new GetAllKTQuery());
                    var _receiptStatus = await _mediator.Send(new GetAllReceiptStatusQuery());

                    var _receiptDTO = MapReceipt.ReceiptToReceiptDTO(_created, _receiptDetails, _kts, _receiptStatus);
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

        // Delete func
        [HttpPut("Confirm/{id}")]
        public async Task<ActionResult<ReceiptDTO>> ConfirmRentCar(Guid id)
        {
            try
            {
                var _receiptById = await _mediator.Send(new GetReceiptByIdQuery { Receipt_ID = id });
                if (_receiptById != null)
                {
                    //Update ReceiptStatus_ID = 2 & Update status = false
                    var _updated = await _mediator.Send(new ConfirmReceiptCommand { Receipt_ID = id });
                    if (_updated != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new { message = "Confirm successful." });
                    }
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // Delete func
        [HttpPut("reject/{id}")]
        public async Task<ActionResult<ReceiptDTO>> RejectRentCar(Guid id)
        {
            try
            {
                var _receiptById = await _mediator.Send(new GetReceiptByIdQuery { Receipt_ID = id});
                if(_receiptById != null)
                {
                    //Update ReceiptStatus_ID = 3 & Update status = true
                    var _updated = await _mediator.Send(new RejectReceiptCommand { Receipt_ID = id });
                    if (_updated != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new { message = "Reject successful." });
                    }
                }
                return StatusCode(StatusCodes.Status400BadRequest);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        // Delete func
        [HttpPut("confirm_return_car/{id}")]
        public async Task<ActionResult<ReceiptDTO>> ConfirmReturnCar(Guid id)
        {
            try
            {
                var _receiptById = await _mediator.Send(new GetReceiptByIdQuery { Receipt_ID = id });
                if (_receiptById != null)
                {
                    //Update ReceiptStatus_ID = 4 & Update status = true
                    var _updated = await _mediator.Send(new ConfirmReturnCarCommand { Receipt_ID = id });
                    if (_updated != null)
                    {
                        return StatusCode(StatusCodes.Status200OK, new { message = "Return car successful." });
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
