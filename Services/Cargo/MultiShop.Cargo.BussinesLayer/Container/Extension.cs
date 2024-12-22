using Microsoft.Extensions.DependencyInjection;
using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.BussinesLayer.Concrete;
using MultiShop.Cargo.DataAccsessLayer.Abstract;
using MultiShop.Cargo.DataAccsessLayer.EntityFramework;
using MultiShop.Cargo.DataAccsessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BussinesLayer.Container
{
    public static class Extension
    {
        public static void AddProjectDepenencies(this IServiceCollection services)
        {
            services.AddScoped<ICargoCompanyDal, EFCargoCompanyDal>();
            services.AddScoped<ICargoCustomerDal, EFCargoCustomerDal>();
            services.AddScoped<ICargoDetailDal, EFCargoDetailDal>();
            services.AddScoped<ICargoOperationDal, EFCargoOperationDal>();

            services.AddScoped<ICargoCompanyService, CargoCampanyManager>();
            services.AddScoped<ICargoCustomerService, CargoCustomerManager>();
      
      


            services.AddScoped<ICargoDetailService, CargoDetailManager>();
            services.AddScoped<ICargoOperationService, CargoOperationManager>();
            services.AddScoped<ICargoOperationService, CargoOperationManager>();



            services.AddScoped(typeof(IGenericDal<>), typeof(GenericRepository<>));
 
       
            





        }
    }
}
