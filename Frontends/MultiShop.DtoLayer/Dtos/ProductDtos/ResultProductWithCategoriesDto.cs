using MultiShop.DtoLayer.Dtos.CategoryDtos;


namespace MultiShop.DtoLayer.Dtos.ProductDtos
{
    public class ResultProductWithCategoriesDto
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductImageUrl { get; set; }
        public string ProductDescription { get; set; }
        public ResultCategoryDto Category { get; set; }
    }
}
