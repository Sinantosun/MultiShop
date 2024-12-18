using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddresCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddresCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                District = createAddressCommand.District,
                Detail1 = createAddressCommand.Detail1,
                UserId = createAddressCommand.UserId,
                Country = createAddressCommand.Country,
                Description = createAddressCommand.Description,
                Detail2 = createAddressCommand.Detail2,
                Email = createAddressCommand.Email,
                Name = createAddressCommand.Name,   
                Phone = createAddressCommand.Phone,
                SurName = createAddressCommand.SurName,
                ZipCode = createAddressCommand.ZipCode,
                
                
            });
        }
    }
}
