using MultishopEcommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using MultishopEcommerce.Order.Application.Features.CQRS.Results.AddressResults;
using MultishopEcommerce.Order.Application.Interfaces;
using MultishopEcommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _repository;
        public GetAddressByIdQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var value = await _repository.GetById(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = value.AddressId,
                City = value.City,
                Detail = value.Detail,
                Distrinct = value.Distrinct,
                UserId = value.UserId,
            };
        }

    }
}
