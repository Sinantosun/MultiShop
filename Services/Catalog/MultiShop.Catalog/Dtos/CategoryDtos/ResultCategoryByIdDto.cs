using MultiShop.Catalog.Entites;

namespace MultiShop.Catalog.Dtos.CategoryDtos
{
    public class ResultCategoryByIdDto : BaseEntity
    {
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
    }
}
