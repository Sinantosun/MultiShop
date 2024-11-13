using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogOfferComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
