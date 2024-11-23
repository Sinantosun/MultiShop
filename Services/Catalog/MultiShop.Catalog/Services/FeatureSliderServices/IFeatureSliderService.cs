using MultiShop.Catalog.Dtos.FeatureSliderDtos;

namespace MultiShop.Catalog.Services.FeatureSliderServices
{
    public interface IFeatureSliderService
    {
        Task<List<ResultFeatureSliderDto>> GetAllFeatureSliderAsync();

        Task<List<ResultFeatureSliderDto>> GetTrueFeatureSliderListAsync();


        Task CreateFeatureSliderAsync(CreateFeatureSliderDto createFeatureSliderDto);
        Task UpdateFeatureSliderAsync(UpdateFeatureSliderDto updateFeatureSliderDto);
        Task DeleteFeatureSliderAsync(string id);
        Task<ResultFeatureSliderByIdDto> GetFeatureSliderByIdAsync(string id);

        Task ChangeFeatureSliderStatusToTrue(string id);
        Task ChangeFeatureSliderStatusToFalse(string id);
    }
}
