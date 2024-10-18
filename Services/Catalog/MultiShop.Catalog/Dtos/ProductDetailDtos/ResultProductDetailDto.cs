using MultiShop.Catalog.Entites;

namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public class ResultProductDetailDto : BaseEntity
    {
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
    }
}
