using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureDtos;

namespace MultiShop.WebUI.Services.CatalogServices.FeatureServices
{
    public interface IFeatureService
    {
        Task<List<ResultFeatueDto>> GetAllFeatureAsync();
        Task<bool> CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task<bool> UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task<bool> DeleteFeatureAsync(string id);
        Task<ResultFeatureByIdDto> GetFeatureByIdAsync(string id);
    }
}
