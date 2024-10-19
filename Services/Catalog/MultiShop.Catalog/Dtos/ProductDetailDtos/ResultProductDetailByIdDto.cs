using MultiShop.Catalog.Entites;

namespace MultiShop.Catalog.Dtos.ProductDetailDtos
{
    public class ResultProductDetailByIdDto : BaseEntity
    {
        public string ProductDescription { get; set; }
        public string ProductInfo { get; set; }
        public string ProductId { get; set; }
    }
}
