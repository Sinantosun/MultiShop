using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.UILayoutComponents
{
    public class UILayoutFooterComponentPartial : ViewComponent
    {
        private readonly IAboutService _aboutService;
        public UILayoutFooterComponentPartial(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _aboutService.GetAllAboutAsync();
            return View(values);
        }
    }
}
