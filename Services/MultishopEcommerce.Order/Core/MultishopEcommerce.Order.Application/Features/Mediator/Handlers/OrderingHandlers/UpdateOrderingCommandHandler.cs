using MediatR;
using MultishopEcommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using MultishopEcommerce.Order.Application.Interfaces;
using MultishopEcommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.OrderingId);
            value.OrderDate = request.OrderDate;
            value.UserId = request.UserId;
            value.TotalPrice = request.TotalPrice; 
            await _repository.Update(value);
        }
    }
}
