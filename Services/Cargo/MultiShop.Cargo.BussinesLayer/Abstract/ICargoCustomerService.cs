﻿using MultiShop.Cargo.EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.BussinesLayer.Abstract
{
    public interface ICargoCustomerService : IGenericService<CargoCustomer>
    {
        Task<CargoCustomer> TGetUserAddresByUserId(string userId);
    }
}
