using MultishopEcommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultishopEcommerce.Order.Application.Interfaces;
using MultishopEcommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var value = await _repository.GetById(command.AddressId);
           value.AddressId = command.AddressId;
            value.UserId = command.UserId;
            value.Distrinct = command.Distrinct;
            value.Detail = command.Detail;
            value.City = command.City;
            await _repository.Update(value);
        }
    }
}
