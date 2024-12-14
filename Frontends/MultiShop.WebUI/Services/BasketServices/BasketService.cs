using MultiShop.DtoLayer.Dtos.BasketDtos;

namespace MultiShop.WebUI.Services.BasketServices
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _httpClient;

        public BasketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task AddBasketItem(BasketItemDto basketItemDto)
        {
            var values = await GetBasket();
            if (values != null)
            {
                if (!values.BasketItem.Any(t => t.ProductId == basketItemDto.ProductId))
                {
                    values.BasketItem.Add(basketItemDto);
                }
                else
                {
                    values = new BasketTotalDto();
                    values.BasketItem.Add(basketItemDto);
                }
            }
            await SaveBasket(values);
        }

        public async Task<bool> RemoveBasketItem(string productId)
        {
            var values = await GetBasket();
            var deletedItem = values.BasketItem.FirstOrDefault(t => t.ProductId == productId);
            var result = await SaveBasket(values);
            if (result)
            {
                return true;
            }
            return false;
        }

        public Task<bool> DeleteBasket(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<BasketTotalDto> GetBasket()
        {
            var response = await _httpClient.GetAsync("baskets");
            var values = await response.Content.ReadFromJsonAsync<BasketTotalDto>();
            return values;
        }

        public async Task<bool> SaveBasket(BasketTotalDto basketTotalDto)
        {
            var response = await _httpClient.PostAsJsonAsync<BasketTotalDto>("baskets", basketTotalDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
