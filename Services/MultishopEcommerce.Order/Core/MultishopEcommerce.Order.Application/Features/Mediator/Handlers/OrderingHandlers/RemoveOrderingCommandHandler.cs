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
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            await _repository.Delete(value);
        }
    }
}
