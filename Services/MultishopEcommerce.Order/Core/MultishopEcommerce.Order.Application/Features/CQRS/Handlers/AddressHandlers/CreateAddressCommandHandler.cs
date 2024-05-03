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
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;
        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand commandHandler)
        {
            await _repository.Create(new Address
            {
                City = commandHandler.City,
                Detail =commandHandler.Detail,
                Distrinct = commandHandler.Distrinct,
                UserId = commandHandler.UserId
            });
        }
    }
}
