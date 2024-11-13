using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogCarouselComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
