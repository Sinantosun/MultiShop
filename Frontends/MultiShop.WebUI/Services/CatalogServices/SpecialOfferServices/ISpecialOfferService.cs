using MultiShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;

namespace MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices
{
    public interface ISpecialOfferService
    {
        Task<List<ResultSpecialOfferDto>> GetAllSpecialOfferAsync();
        Task<bool> CreateSpecialOfferAsync(CreateSpecialOfferDto createSpecialOfferDto);
        Task<bool> UpdateSpecialOfferAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
        Task<bool> DeleteSpecialOfferAsync(string id);
        Task<ResultSpecialOfferByIdDto> GetSpecialOfferByIdAsync(string id);
    }
}
