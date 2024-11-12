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
    public class CargoOperationManager : GenericManager<CargoOperation>, ICargoOperationService
    {
        public CargoOperationManager(IGenericDal<CargoOperation> genericDal) : base(genericDal)
        {
        }
    }
}
