namespace MultiShop.Catalog.Dtos.ProductAttributeTypeValueDtos
{
    public class UpdateProductAttributeTypeValueDto
    {
        public string ProductAttributeTypeValueId { get; set; }



        public string ProductId { get; set; }
        public string ProductAttributeTypeId { get; set; }
        public string AttributeValue { get; set; }
    }
}
