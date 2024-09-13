using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Create;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Delete;
using Real_Estate.Application.Features.Mediator.Properties.Commands.Update;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetById;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetList;
using Real_Estate.Application.Features.Mediator.Properties.Queries.GetListByUserId;

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
    }
}
