using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogSpecialOfferComponentPartial : ViewComponent
    {
        private readonly ISpecialOfferService _specialOfferService;
        public CatalogSpecialOfferComponentPartial(ISpecialOfferService specialOfferService)
        {
            _specialOfferService = specialOfferService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(result);

        }
    }
}
