using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogProductComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
