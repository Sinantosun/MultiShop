using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogVendorComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
