using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IProductService _productService;

        public DefaultController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Vitrin";

            return View();
        }

        public async Task<IActionResult> ProductList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";

            var values = await _productService.GetAllProductAsync();
            return View(values);
        }
    }
}
