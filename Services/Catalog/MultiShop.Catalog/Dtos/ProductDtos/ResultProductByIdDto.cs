using MultiShop.Catalog.Entites;

namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductByIdDto : BaseEntity
    {
        public int ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
    }
}
