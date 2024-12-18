using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpGet("GetOrderingByUserId/{id}")]
        public async Task<IActionResult> GetOrderingByUserId(string id)
        {
            var value = await _mediator.Send(new GetOrderingByUserIdQuery(id));
            return Ok(value);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(value);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);  
            return Ok();
        } 
    }
}
