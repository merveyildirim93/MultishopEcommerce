using MultishopEcommerce.Order.Application.Interfaces;
using MultishopEcommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultishopEcommerce.Order.Application.Features.CQRS.Commands.AddressCommands
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
            await _repository.Update(new Address
            {
                City = value.City,
                Detail = value.Detail,
                Distrinct = value.Distrinct,
                UserId = value.UserId,
                AddressId = value.AddressId
            }); 
        }

    }
}
