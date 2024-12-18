using MultiShop.DtoLayer.Dtos.OrderingDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderingServices
{
    public interface IOrderingService
    {
        public Task<List<ResultOrderingByUserIdDto>> GetOrderingByUserId(string userId);
    }
}
