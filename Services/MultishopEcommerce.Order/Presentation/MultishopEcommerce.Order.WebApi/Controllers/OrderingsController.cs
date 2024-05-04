using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultishopEcommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultishopEcommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
using MultishopEcommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultishopEcommerce.Order.WebApi.Controllers
{
    [Route("api/[controller]{[action]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderingList()
        {
            var orderings = await _mediator.Send(new GetOrderingQuery());
            return Ok(orderings);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderingById(int id)
        {
            var ordering = await _mediator.Send(new GetOrderingByIdQuery(id));
            return Ok(ordering);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrdering(CreateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi");
        }

        [HttpPut]
        public async Task<IActionResult> DeleteOrdering(int id)
        {
            await _mediator.Send(new RemoveOrderingCommand(id));
            return Ok("Sipariş başarıyla silindi");
        }

    }
}
