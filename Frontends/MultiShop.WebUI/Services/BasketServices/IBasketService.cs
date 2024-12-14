using MultiShop.DtoLayer.Dtos.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket();
        Task<bool> SaveBasket(BasketTotalDto basketTotalDto);
        Task<bool> DeleteBasket(string userId);

        Task AddBasketItem(BasketItemDto basketItemDto);

        Task<bool> RemoveBasketItem(string productId);
    }
}
