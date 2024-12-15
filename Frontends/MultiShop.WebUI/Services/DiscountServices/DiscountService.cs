using MultiShop.DtoLayer.Dtos.DiscountDtos;

namespace MultiShop.WebUI.Services.DiscountServices
{
    public class DiscountService : IDiscountService
    {
        private readonly HttpClient _httpClient;

        public DiscountService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<GetDiscountCodeDetailByCode> GetDiscountCodeAsync(string code)
        {
            var response = await _httpClient.GetFromJsonAsync<GetDiscountCodeDetailByCode>($"coupon/GetCodeDetailByCode/{code}");
            if (response != null)
            {
                return response;
            }
            return new GetDiscountCodeDetailByCode();
        }

        public async Task<int> GetDiscountRateAsync(string code)
        {
            var response = await _httpClient.GetFromJsonAsync<int>($"coupon/GetCouponRateByCoupon/{code}");

            return response;
        }
    }
}
