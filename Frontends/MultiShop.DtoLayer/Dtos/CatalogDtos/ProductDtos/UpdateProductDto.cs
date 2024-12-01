

namespace MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos
{
    public class UpdateProductDto 
    {
        public string Id { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public string CategoryId { get; set; }
    }
}
