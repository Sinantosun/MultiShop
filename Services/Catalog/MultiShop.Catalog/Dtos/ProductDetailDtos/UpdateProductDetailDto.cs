using MultiShop.Catalog.Entites;

namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public class UpdateProductDetailDto : BaseEntity
    {
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
    }
}
