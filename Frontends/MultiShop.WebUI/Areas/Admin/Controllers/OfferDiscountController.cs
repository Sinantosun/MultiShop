using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.OfferDiscountDtos;
using MultiShop.WebUI.Services;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class OfferDiscountController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly NotificationService _notificationService;
        public OfferDiscountController(IHttpClientFactory httpClientFactory, NotificationService notificationService)
        {
            _httpClientFactory = httpClientFactory;
            _notificationService = notificationService;
        }
        public async Task<IActionResult> Index()
        {

            ViewBag.PageTitle = "Ana Sayfa İndirim İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ana Sayfa İndirimler";
            ViewBag.v6 = "Ana Sayfa İndirim Listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/OfferDiscounts");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
                return View(result);
            }
            return View(new List<ResultOfferDiscountDto>());
        }

        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.PageTitle = "Ana Sayfa İndirim İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ana Sayfa İndirimler";
            ViewBag.v6 = "Ana Sayfa İndirim Ekle";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";


            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createOfferDiscountDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/OfferDiscounts", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Yeni kayıt eklendi.");
                return RedirectToAction("Index");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
                return RedirectToAction("CreateOfferDiscount");
            }
         

        }


        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.PageTitle = "Ana Sayfa İndirim İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ana Sayfa İndirimler";
            ViewBag.v6 = "Ana Sayfa İndirim Güncelle";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/OfferDiscounts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultOfferDiscountByIdDto>(jsonData);

                return View(result);

            }
            return View(new ResultOfferDiscountByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(updateOfferDiscountDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/OfferDiscounts", str);
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


        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/OfferDiscounts/{id}");
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

