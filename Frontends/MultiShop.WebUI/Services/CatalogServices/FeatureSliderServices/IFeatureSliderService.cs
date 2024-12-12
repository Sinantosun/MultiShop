using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();

        Task<List<ResultFeatureSliderDto>> GetTrueFeatureSliderListAsync();


        Task<bool> CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task<bool> UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task<bool> DeleteFeatureSliderAsync(string id);
        Task<ResultFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id);

        Task<bool> ChangeFeatureSliderStatusToTrue(string id);
        Task<bool> ChangeFeatureSliderStatusToFalse(string id);
    }
}
