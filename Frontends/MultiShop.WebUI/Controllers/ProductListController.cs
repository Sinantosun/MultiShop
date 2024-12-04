using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly NotificationService _notificationService;
        public ProductListController(IHttpClientFactory httpClientFactory, NotificationService notificationService)
        {
            _httpClientFactory = httpClientFactory;
            _notificationService = notificationService;
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
        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateUserCommentDto createUserCommentDto)
        {
            createUserCommentDto.Status = true;
            createUserCommentDto.CreatedDate = DateTime.Now;
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(createUserCommentDto);
            StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7075/api/Comments", str);
            if (responseMessage.IsSuccessStatusCode)
            {
                _notificationService.Success("Yorumunz Eklendi");
                return RedirectToAction("ProductDetail", new { id = createUserCommentDto.ProductId });
            }
            else
            {
                _notificationService.Warning("Bir Hata Oluştu");

                return RedirectToAction("ProductDetail", new { id = createUserCommentDto.ProductId });

            }


        }
    }
}
