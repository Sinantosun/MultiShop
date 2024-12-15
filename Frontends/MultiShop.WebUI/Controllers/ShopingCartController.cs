using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Controllers
{
    public class ShopingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly NotificationService _notificationService;
        public ShopingCartController(IProductService productService, IBasketService basketService, NotificationService notificationService)
        {
            _productService = productService;
            _basketService = basketService;
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Sepetim";

            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetProductByIdAsync(id);
            var items = new BasketItemDto
            {
                Price = values.ProductPrice,
                ProductId = id,
                ProductName = values.ProductName,
                ImageUrl = values.ProductImageUrl,
                Quantity = 1,
            };
            var result = await _basketService.AddBasketItem(items);
            if (result)
            {
                _notificationService.Success("Sepet başarıyla güncellendi");
            }
            else
            {
                _notificationService.Error("Lütfen sepetinize ürün eklemek için giriş yapınız");

            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            var result = await _basketService.RemoveBasketItem(id);
            if (result)
            {
                _notificationService.Success("Sepet başarıyla güncellendi");
            }
            else
            {
                _notificationService.Error("Ürün sepetinizden çıkartılırken bir hata oluştu");

            }
            return RedirectToAction("Index");
        }
    }
}
