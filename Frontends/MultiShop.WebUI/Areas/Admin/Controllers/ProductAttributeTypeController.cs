using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.ProductAttributeTypeDtos;
using MultiShop.WebUI.Services;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductAttributeTypeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly NotificationService _notificationService;
        public ProductAttributeTypeController(IHttpClientFactory httpClientFactory, NotificationService notificationService)
        {
            _httpClientFactory = httpClientFactory;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.PageTitle = "Hakkımızda  İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Hakkımızda alanı";
            ViewBag.v6 = "Hakkımızda listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/ProductAttributeTypes");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultProductAttributeTypeDto>>(jsonData);
                return View(result);
            }
            return View(new List<ResultProductAttributeTypeDto>());
        }

        [HttpGet]
        public IActionResult CreateProductAttribute()
        {
            ViewBag.PageTitle = "Hakkımızda  İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Hakkımızda alanı";
            ViewBag.v6 = "Hakkımızda ekleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateProductAttribute(CreateProductAttributeTypeDto createProductAttributeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createProductAttributeDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/ProductAttributeTypes", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Yeni kayıt eklendi.");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
            }
            return RedirectToAction("CreateProductAttribute");

        }


        [HttpGet]
        public async Task<IActionResult> UpdateProductAttribute(string id)
        {
            ViewBag.PageTitle = "Hakkımızda İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Hakkımızda alanı";
            ViewBag.v6 = "Hakkımızda güncelleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/ProductAttributeTypes/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultProductAttributeTypeByIdDto>(jsonData);

                return View(result);

            }
            _notificationService.Error("Beklenmeyen bir hata meydana geldi.");
            return View(new ResultProductAttributeTypeByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductAttribute(UpdateProductAttributeTypeDto updateProductAttributeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(updateProductAttributeDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/ProductAttributeTypes", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Kayıt güncellendi.");
                return RedirectToAction("Index");
            }
            else
            {
                _notificationService.Error("Kayıt güncelleme sırasında bir hata oluştu.");
            }
            return View();

        }

        public async Task<IActionResult> DeleteProductAttribute(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/ProductAttributeTypes/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Kayıt silindi.");
            }
            else
            {
                _notificationService.Error("Kayıt silme esnasında bir hata oluştu.");
            }
            return RedirectToAction("Index");
        }
    }
}
