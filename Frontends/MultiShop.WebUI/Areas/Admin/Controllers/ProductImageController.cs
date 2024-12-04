using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductImageDtos;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly NotificationService _notificationService;
        public ProductImageController(IHttpClientFactory httpClientFactory, NotificationService notificationService)
        {
            _httpClientFactory = httpClientFactory;
            _notificationService = notificationService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductImageDetail(string id)
        {
            ViewBag.PageTitle = "Ürün Görsel İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ürünler";
            ViewBag.v6 = "Ürün Görserseli Güncelleme Sayfası";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/ProductImages/GetProductImageListByProductId?productId={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultProductImageByProductIdDto>(jsonData);

                return View(result);

            }
            _notificationService.Error("Beklenmeyen bir hata meydana geldi.");
            return View(new ResultProductImageByProductIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> ProductImageDetail(UpdateProductImageDto updateAboutDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(updateAboutDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/ProductImages", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Kayıt güncellendi.");
                return RedirectToAction("Index", "Product");
            }
            else
            {
                _notificationService.Error("Kayıt güncelleme sırasında bir hata oluştu.");
            }
            return RedirectToAction("Index","Product");

        }
    }
}
