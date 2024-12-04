using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SpecialOfferController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly NotificationService _notificationService;
        public SpecialOfferController(IHttpClientFactory httpClientFactory, NotificationService notificationService)
        {
            _httpClientFactory = httpClientFactory;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.PageTitle = "Özel Teklif Alanı";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Özel Teklifler";
            ViewBag.v6 = "Özel Teklif Listesi";


            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialOffers");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
                return View(result);
            }
            return View(new List<ResultSpecialOfferDto>());
        }

        [HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.PageTitle = "Özel Teklif Alanı";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Özel Teklifler";
            ViewBag.v6 = "Özel Teklif Listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createSpecialOfferDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/SpecialOffers", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Yeni kayıt eklendi.");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
            }
            return RedirectToAction("CreateSpecialOffer");

        }


        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.PageTitle = "Özel Teklif Alanı";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Özel Teklifler";
            ViewBag.v6 = "Özel Teklif Listesi";


            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/SpecialOffers/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultSpecialOfferByIdDto>(jsonData);
                return View(result);
            }
            _notificationService.Error("Beklenmeyen bir hata meydana geldi.");
            return View(new ResultSpecialOfferByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(updateSpecialOfferDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/SpecialOffers", str);
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


        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/SpecialOffers/{id}");
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
