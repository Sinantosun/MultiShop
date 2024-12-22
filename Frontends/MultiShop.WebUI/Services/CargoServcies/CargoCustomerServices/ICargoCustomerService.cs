using MultiShop.DtoLayer.Dtos.CargoDtos.CargoCustomerDtos;

namespace MultiShop.WebUI.Services.CargoServcies.CargoCustomerServices
{
    public interface ICargoCustomerService
    {
        Task<GetCargoCustomerByCustometIdDto> GetUserAddresByUserId(string userId);

    }
}
