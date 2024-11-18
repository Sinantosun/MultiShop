using MultiShop.Catalog.Dtos.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductWithCategoriesDto
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
