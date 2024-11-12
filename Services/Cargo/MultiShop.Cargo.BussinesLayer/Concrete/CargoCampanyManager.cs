using MultiShop.Cargo.BussinesLayer.Abstract;
using MultiShop.Cargo.DataAccsessLayer.Abstract;
using MultiShop.Cargo.EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BussinesLayer.Concrete
{
    public class CargoCampanyManager : GenericManager<CargoCompany>, ICargoCompanyService
    {
        public CargoCampanyManager(IGenericDal<CargoCompany> genericDal) : base(genericDal)
        {
        }
    }
}
