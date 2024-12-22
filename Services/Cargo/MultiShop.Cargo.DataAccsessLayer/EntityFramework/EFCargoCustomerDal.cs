using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccsessLayer.Abstract;
using MultiShop.Cargo.DataAccsessLayer.Concrete;
using MultiShop.Cargo.DataAccsessLayer.Repositories;
using MultiShop.Cargo.EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccsessLayer.EntityFramework
{
    public class EFCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
    {
        public EFCargoCustomerDal(CargoContext context) : base(context)
        {
        }

        public async Task<CargoCustomer> GetUserAddresByUserId(string userId)
        {
            var values = await _context.CargoCustomers.FirstOrDefaultAsync(t => t.UserCustomerId == userId);
            return values;
        }

      
    }
}
