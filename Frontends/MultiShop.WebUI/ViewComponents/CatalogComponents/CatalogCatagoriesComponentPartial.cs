using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogCatagoriesComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CatalogCatagoriesComponentPartial( ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _categoryService.GetCategoriesWithCountsAsync();
            return View(values);

        }
    }
}
