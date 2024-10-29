using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectQLThueXe.Application.KT.Queries;
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
            }catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);

            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult>
    }
}
