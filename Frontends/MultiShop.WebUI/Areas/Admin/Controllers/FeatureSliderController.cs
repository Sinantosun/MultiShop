using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FeatureSliderController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly NotificationService _notificationService;
        public FeatureSliderController(IHttpClientFactory httpClientFactory, NotificationService notificationService)
        {
            _httpClientFactory = httpClientFactory;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Slider İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Slider";
            ViewBag.v6 = "Slider Görselleri";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/FeatureSliders");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(result);
            }
            return View(new List<ResultFeatureSliderDto>());
        }

        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.PageTitle = "Slider İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Slider";
            ViewBag.v6 = "Slider Ekleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/FeatureSliders", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Kayıt Eklendi");
                return RedirectToAction("Index");
            }
            _notificationService.Error("Bir Hata oluştu lütfen tekrar deneyin");
            return View(createFeatureSliderDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.PageTitle = "Slider İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Slider";
            ViewBag.v6 = "Slider Güncelleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/FeatureSliders/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultFeatureSliderByIdDto>(jsonData);
                return View(result);
            }
            return View(new ResultFeatureSliderByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/FeatureSliders", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Kayıt Güncellendi");
                return RedirectToAction("Index");
            }
            _notificationService.Error("Bir Hata oluştu lütfen tekrar deneyin");
            return View(updateFeatureSliderDto);
        }



        public async Task<IActionResult> ChangeSliderStatusToTrue(string id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/FeatureSliders/ChangStatusToTrue?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Slider yayına alındı");
                return RedirectToAction("Index");
            }
            _notificationService.Error("Slider yayına alınırken bir sorun oluştu lütfen tekarar deneyin.");
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> ChangeSliderStatusToFalse(string id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/FeatureSliders/ChangStatusToFalse?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Slider yayından kaldırıldı");
                return RedirectToAction("Index");
            }
            _notificationService.Error("Slider yayından kaldırılırken bir sorun oluştu lütfen tekarar deneyin.");
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/FeatureSliders/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Slider kaydı silindi");
                return RedirectToAction("Index");
            }
            _notificationService.Error("Slider kaydi silinemedi bir hata oluştu ");
            return RedirectToAction("Index");
        }

    }
}
