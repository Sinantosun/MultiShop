using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos
{
    public class ResultCargoDetailByIdDto
    {
        public int CargoDetailId { get; set; }
        public string SenderCustomer { get; set; }

        public string ReciverCustomer { get; set; }
        public int Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
