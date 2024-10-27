using Microsoft.Extensions.DependencyInjection;
using MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.Mediator.Handlers.OrderingHandlers;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Persistence.Container
{
    public static class Extension
    {
        public static void ProjectDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), (typeof(Repository<>)));
            services.AddScoped<GetAddressQueryHandler>();
            services.AddScoped<GetAddressByIdQueryHandler>();
            services.AddScoped<CreateAddresCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();
            services.AddScoped<RemoveAddressCommandHandler>();


            services.AddScoped<GetOrderDetailQueryHandler>();
            services.AddScoped<GetOrderDetailByIdQueryHandler>();
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();

            services.AddMediatR(opts =>
            {
                opts.RegisterServicesFromAssemblyContaining<GetOrderingQueryHandler>();
            });

        }
    }
}
