namespace MultiShop.Catalog.Dtos.ProductAttributeTypeValueDtos
{
    public class ResultProductAttributeTypeValueByProductIdDto
    {
        public string AttributeName { get; set; }

        public List<AttributeTypeValue> Values { get; set; }
    }

    public class AttributeTypeValue
    {
        public string Value { get; set; }
        public bool IsExsit { get; set; }
    }
}
