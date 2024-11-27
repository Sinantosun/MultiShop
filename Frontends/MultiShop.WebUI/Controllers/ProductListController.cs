using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index(string id)
        {
            ViewBag.CategoryId = id;
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Listesi";

            return View();
        }

        public async Task<IActionResult> ProductDetail(string id)
        {
            ViewBag.ProductId = id;
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Ürünler";
            ViewBag.v3 = "Ürün Detayı";


            return View();
        }
    }
}
