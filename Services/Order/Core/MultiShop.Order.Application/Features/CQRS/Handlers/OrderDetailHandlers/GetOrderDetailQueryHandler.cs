using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{

    public class GetOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(t => new GetOrderDetailQueryResult
            {
                ProductPrice = t.ProductPrice,
                OrderingId = t.OrderingId,
                ProductAmount = t.ProductAmount,
                ProductId = t.ProductId,
                ProductName = t.ProductName,
                PrdouctTotalPrice = t.PrdouctTotalPrice,
            }).ToList();
        }
    }
}
