namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public class ResultCategoryWithCountDto
    {
        public string Id { get; set; }
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryCount { get; set; }
    }
}
