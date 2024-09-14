using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Approve;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Create;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Delete;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Reject;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Update;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetById;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetList;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetlistApprove;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetListByApproveCount;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetListByUserId;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetPropertiesFilter;

namespace Real_Estate.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PropertyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("PropertyListUserId/{id}")]
        public async Task<IActionResult> PropertyListUserId(int id)
        {
            var values = await _mediator.Send(new GetListByUserIdPropertyQuery(id));

            return Ok(values);
        }
		
	    [HttpGet("CountApprova")]
		public async Task<IActionResult> GetPendingApprova()
		{
			var values = await _mediator.Send(new GetPendingApprovalCountQuery());

			return Ok(values);
		}
		[HttpGet("PropertyPendingApproveList")]
        public async Task<IActionResult> PropertyPendingApproveList()
        {
            var values = await _mediator.Send(new GetListPendingApprovePropertyQuery());

            return Ok(values);
        }
		[HttpGet("PropertyApproveList")]
		public async Task<IActionResult> PropertyApproveList()
		{
			var values = await _mediator.Send(new GetListApprovePropertyQuery());

			return Ok(values);
		}
		[HttpGet]
		public async Task<IActionResult> PropertyList()
		{
			var values = await _mediator.Send(new GetListPropertyQuery());

			return Ok(values);
		}
		[HttpGet("{id}")]
        public async Task<IActionResult> GetProperty(int id)
        {
            GetByIdPropertyQuery getByIdProperty = new() { Id = id };

            var value = await _mediator.Send(getByIdProperty);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreatedPropertyCommand createdPropertyCommand)
        {
            CreatedPropertyResponse response = await _mediator.Send(createdPropertyCommand);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePropertyCommand updatePropertyCommand)
        {
            UpdatePropertyResponse response = await _mediator.Send(updatePropertyCommand);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            DeletePropertyResponse response = await _mediator.Send(new DeletePropertyCommand(id));

            return Ok(response);
        }

		[HttpPost("Approve/{id}")]
		public async Task<IActionResult> Approve(int id)
		{
			var result = await _mediator.Send(new ApprovePropertyCommand { PropertyId = id });
			return result ? Ok() : NotFound();
		}

		[HttpPost("Reject/{id}")]
		public async Task<IActionResult> Reject(int id)
		{
			var result = await _mediator.Send(new RejectPropertyCommand { PropertyId = id });
			return result ? Ok() : NotFound();
		}

		[HttpGet("Filter")]
		public async Task<IActionResult> Get([FromQuery] string status, [FromQuery] DateTime? date)
		{
			var properties = await _mediator.Send(new GetPropertiesFilterQuery { Status = status, Date = date });
			return Ok(properties);
		}
	}
}
