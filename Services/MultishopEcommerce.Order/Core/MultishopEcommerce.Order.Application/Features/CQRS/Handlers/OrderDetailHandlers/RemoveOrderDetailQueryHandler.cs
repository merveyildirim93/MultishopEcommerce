using MultishopEcommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultishopEcommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultishopEcommerce.Order.Application.Interfaces;
using MultishopEcommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class RemoveOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;
        public RemoveOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderDetailCommand command)
        {
            var value = await _repository.GetById(command.Id);
            await _repository.Delete(value);

        }
    }
}
