using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.CatalogComponents
{
    public class CatalogFeatureComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
