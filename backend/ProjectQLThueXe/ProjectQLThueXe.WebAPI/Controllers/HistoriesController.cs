using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectQLThueXe.Application.History.Queries;
using ProjectQLThueXe.Application.KT.Queries;
using ProjectQLThueXe.Application.Mapping;
using ProjectQLThueXe.Application.ReceiptDetail.Queries;
using ProjectQLThueXe.Application.ReceiptStatus.Queries;
using ProjectQLThueXe.Domain.DTOs;

namespace ProjectQLThueXe.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public HistoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Get all car renter 
        /// </summary>
        /// <returns>Return the list of customers who have rented or are currently renting a car with status code 200</returns>
        [HttpGet("kt_rent")]
        public async Task<ActionResult<IEnumerable<KTRentDTO>>> GetKTRent()
        {
            try
            {
                var _ktRent = await _mediator.Send(new GetAllKTRentQuery());
                var _receiptDetail = await _mediator.Send(new GetAllReceiptDetailQuery());
                var _kts = await _mediator.Send(new GetAllKTQuery());
                var _receiptStatus = await _mediator.Send(new GetAllReceiptStatusQuery());
                var _ktRentDTO = MapKt.ListKtRentToListKTRentDTO(_ktRent, _receiptDetail, _kts, _receiptStatus);
                if (_ktRentDTO == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest);
                }

                return StatusCode(StatusCodes.Status200OK, _ktRentDTO);
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
        /// <returns>Return car renter with status code 200</returns>
        [HttpGet("kt_rent/{id}")]
        public async Task<ActionResult<KTRentDTO>> GetKTRentById(Guid id)
        {
            try
            {
                var _ktRent = await _mediator.Send(new GetKTRentByIdQuery { KT_ID = id});
                var _receiptDetail = await _mediator.Send(new GetAllReceiptDetailQuery());
                var _kts = await _mediator.Send(new GetAllKTQuery());
                var _receiptStatus = await _mediator.Send(new GetAllReceiptStatusQuery());
                var _ktRentDTO = MapKt.KtRentToKTRentDTO(_ktRent, _receiptDetail, _kts, _receiptStatus);
                if (_ktRentDTO != null)
                {
                    return StatusCode(StatusCodes.Status200OK, _ktRentDTO);
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
