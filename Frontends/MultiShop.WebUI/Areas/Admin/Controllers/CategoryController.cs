using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CategoryDtos;
using MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;
using MultiShop.WebUI.Services;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly NotificationService _notificationService;
        public CategoryController(IHttpClientFactory httpClientFactory, NotificationService notificationService)
        {
            _httpClientFactory = httpClientFactory;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {



            ViewBag.PageTitle = "Kategori İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Kategoriler";
            ViewBag.v6 = "Kategori Listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i2 = "fa-bars";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(result);
            }
            return View(new List<ResultCategoryDto>());
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.PageTitle = "Kategori İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Kategoriler";
            ViewBag.v6 = "Kategori Ekle";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i2 = "fa-bars";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createCategoryDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/Categories", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Yeni kayıt eklendi.");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
            }
            return View();

        }


        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.PageTitle = "Kategori İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Kategoriler";
            ViewBag.v6 = "Kategori Güncelle";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i2 = "fa-bars";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/Categories/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ResultCategoryByIdDto>(jsonData);
                return View(result);
            }
            return View(new ResultCategoryByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/Categories", str);
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


        public async Task<IActionResult> DeleteCategory(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7070/api/Categories/{id}");
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
