using MultiShop.DtoLayer.Dtos.CargoDtos.CargoCompanyDtos;

namespace MultiShop.WebUI.Services.CargoServcies.CargoCompanyServices
{
    public interface ICargoCompanyService
    {
        Task<List<ResultCargoDto>> GetAllCargoAsync();
        Task<bool> CreateCargoAsync(CreateCargoDto createCargoDto);
        Task<bool> UpdateCargoAsync(UpdateCargoDto updateCargoDto);
        Task<bool> DeleteCargoAsync(int id);
        Task<ResultCargoByIdDto> GetCargoByIdAsync(int id);
    }
}
