using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.DiscountServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShopingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        private readonly IDiscountService _discountService;
        private readonly NotificationService _notificationService;
        public ShopingCartController(IProductService productService, IBasketService basketService, NotificationService notificationService, IDiscountService discountService)
        {
            _productService = productService;
            _basketService = basketService;
            _notificationService = notificationService;
            _discountService = discountService;
        }

        public async Task<IActionResult> Index(string? code)
        {

            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Sepetim";

            var values = await _basketService.GetBasket();

            if (string.IsNullOrEmpty(code))
            {
                if (values != null)
                {
                    var totalpricewithtax = ((values.TotalPrice * 10) / 100) + values.TotalPrice;
                    decimal tax = (values.TotalPrice * 10) / 100;

                    ViewBag.TotalpriceWithTax = totalpricewithtax;
                    ViewBag.tax = tax;
                    ViewBag.CartTotal = values.TotalPrice;
                }
            }
            else
            {
                TempData["discount"] = code;
                var rate = await _discountService.GetDiscountRateAsync(code);

                var tax = (values.TotalPrice * 10) / 100;

                var totalprice = values.TotalPrice;

                var totalpricewithtax = totalprice + tax;

                var discountrate = (totalpricewithtax * rate / 100);

                ViewBag.totalpriceWithTax = totalpricewithtax - discountrate;
                ViewBag.tax = tax;
                ViewBag.cartTotal = values.TotalPrice;
                ViewBag.discountrate = rate;
                ViewBag.newtotalprice = discountrate;

                ViewBag.price = tax + totalprice;

            }

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
