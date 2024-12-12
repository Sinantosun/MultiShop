using MultiShop.DtoLayer.Dtos.CatalogDtos.OfferDiscountDtos;

namespace MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices
{
    public interface IOfferDiscountService
    {
        Task<List<ResultOfferDiscountDto>> GetAllOfferDiscountAsync();
        Task<bool> CreateOfferDiscountAsync(CreateOfferDiscountDto createOfferDiscountDto);
        Task<bool> UpdateOfferDiscountAsync(UpdateOfferDiscountDto updateOfferDiscountDto);
        Task<bool> DeleteOfferDiscountAsync(string id);
        Task<ResultOfferDiscountByIdDto> GetOfferDiscountByIdAsync(string id);
    }
}
