using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            value.ProductName = command.ProductName;
            value.ProductId = command.ProductId;    
            value.PrdouctTotalPrice = command.PrdouctTotalPrice;
            value.ProductAmount = command.ProductAmount;  
            value.ProductPrice = command.ProductPrice;  
            value.OrderingId = command.OrderingId;
            await _repository.UpdateAsync(value);   

        }
    }
}
