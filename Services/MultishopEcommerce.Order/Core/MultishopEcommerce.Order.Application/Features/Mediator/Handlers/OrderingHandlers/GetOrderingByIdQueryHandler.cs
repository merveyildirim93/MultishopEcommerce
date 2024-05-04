using MediatR;
using MultishopEcommerce.Order.Application.Features.Mediator.Queries.OrderingQueries;
using MultishopEcommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using MultishopEcommerce.Order.Application.Interfaces;
using MultishopEcommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Order.Application.Features.Mediator.Handlers.OrderingHandlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetById(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderDate = value.OrderDate,
                OrderingId = value.OrderingId,
                TotalPrice = value.TotalPrice,
                UserId = value.UserId
            };
        }
    }
}
