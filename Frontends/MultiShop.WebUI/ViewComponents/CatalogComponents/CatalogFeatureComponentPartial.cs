using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogFeatureComponentPartial : ViewComponent
    {
        private readonly IFeatureService _featureService;
        public CatalogFeatureComponentPartial( IFeatureService featureService)
        {
            _featureService = featureService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           var values  = await _featureService.GetAllFeatureAsync();
            return View(values);
        }
    }
}
