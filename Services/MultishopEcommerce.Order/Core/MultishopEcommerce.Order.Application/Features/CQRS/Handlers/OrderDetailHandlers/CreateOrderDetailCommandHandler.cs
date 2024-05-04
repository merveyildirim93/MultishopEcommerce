using MultishopEcommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultishopEcommerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultishopEcommerce.Order.Application.Interfaces;
using MultishopEcommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.Create(new OrderDetail
            {
                ProductTotalPrice = command.ProductTotalPrice,
                ProductPrice = command.ProductPrice,
                ProductName = command.ProductName,
                OrderingId = command.OrderingId,
                ProductAmount = command.ProductAmount,
                ProductId = command.ProductId
            });
        }
    }
}
