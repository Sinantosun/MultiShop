namespace MultiShop.DtoLayer.Dtos.BasketDtos
{
    public class BasketTotalDto
    {
        public string UserId { get; set; }
        public string? DiscountCode { get; set; }
        public int? DisountRate { get; set; }
        public List<BasketItemDto> BasketItem { get; set; }
        public decimal TotalPrice { get => BasketItem.Sum(t => t.Price * t.Quantity); }

        public bool? ResponseMessage { get; set; }
        public string? Message { get; set; }

    }
}
