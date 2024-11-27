namespace MultiShop.Catalog.Dtos.ProductDtos
{
    public class ResultProductWithAttrubtuitesDto
    {
        //public string ProductId { get; set; }
        public string TypeName { get; set; }
        //public string ProductName { get; set; }
        //public decimal ProductPrice { get; set; }
        //public string ProductImageUrl { get; set; }
        //public string ProductDescription { get; set; }
        //public string CategoryId { get; set; }
        public List<ProductDetailAttrubiteDto> Attrubuties { get; set; }
    }

}
