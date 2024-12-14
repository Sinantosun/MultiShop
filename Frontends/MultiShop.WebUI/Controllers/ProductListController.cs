using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly NotificationService _notificationService;
        private readonly ICommentService _commentService;
        public ProductListController(NotificationService notificationService, ICommentService commentService)
        {
            _notificationService = notificationService;
            _commentService = commentService;
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
            bool result = await _commentService.CreateComment(createUserCommentDto);
            if (result)
            {
                _notificationService.Success("Yorumunz Eklendi");
                return RedirectToAction("ProductDetail", new { id = createUserCommentDto.ProductId });

            }
            _notificationService.Warning("Bir Hata Oluştu");
            return RedirectToAction("ProductDetail", new { id = createUserCommentDto.ProductId });
        }
    }
}
