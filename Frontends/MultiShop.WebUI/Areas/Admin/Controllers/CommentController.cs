using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CommentDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICommentService _commentService;
        private readonly IProductService _productService;
        public CommentController(IHttpClientFactory httpClientFactory, ICommentService commentService, IProductService productService)
        {
            _httpClientFactory = httpClientFactory;
            _commentService = commentService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
           
            ViewBag.PageTitle = "Ürün Yorum İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ürün Yorumları alanı";
            ViewBag.v6 = "Ürün Yorumları listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";
            var values = await _commentService.GetComments();
          
            if (values != null)
            {
                foreach (var item in values)
                {
                    var productvalues = await _productService.GetProductNameByProductId(item.ProductId);
                    item.ProductName = productvalues.ProductName;
                }
                return View(values);
            }
            return View(new List<ResultUserCommentDto>());
        }
    }
}
