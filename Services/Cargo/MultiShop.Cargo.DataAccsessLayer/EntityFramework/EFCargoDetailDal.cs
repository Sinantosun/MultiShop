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
    public class EFCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EFCargoDetailDal(CargoContext context) : base(context)
        {
        }
    }
}
