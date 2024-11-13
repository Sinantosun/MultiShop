using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogCatagoriesComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
