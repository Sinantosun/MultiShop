using MultiShop.DtoLayer.Dtos.OrderAddressDtos;

namespace MultiShop.WebUI.Services.OrderServices.OrderAddressServices
{
    public interface IOrderAdressService
    {
        //Task<List<ResultAboutDto>> GetAllAboutAsync();
        Task<bool> CreateOrderAddressAsync(CreateOrderAddressDto createOrderAddressDto);
        //Task<bool> UpdateAboutAsync(UpdateAboutDto updateAboutDto);
        //Task<bool> DeleteAboutAsync(string id);
        //Task<ResultAboutByIdDto> GetAboutByIdAsync(string id);
    }
}
