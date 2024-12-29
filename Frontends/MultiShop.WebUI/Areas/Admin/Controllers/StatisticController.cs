using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.CommentStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly ICommentStatisticService _commentStatisticService;
        private readonly IMessageService _messageService;
        private readonly IProductService _productService;
        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentStatisticService commentStatisticService, IDiscountStatisticService discountStatisticService, IMessageService messageService, IProductService productService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentStatisticService = commentStatisticService;
            _discountStatisticService = discountStatisticService;
            _messageService = messageService;
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var brandCount = await _catalogStatisticService.GetBrandCount();
            var categoryCount = await _catalogStatisticService.GetCategoryCount();
            var productCount = await _catalogStatisticService.GetProductCount();
            var avgProductCount = await _catalogStatisticService.GetProductAvgPrice();
            var maxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            var minPriceProductName = await _catalogStatisticService.GetMinPriceProductName();

            var minPrice = await _catalogStatisticService.GetMinPriceProductPrice();
            var maxPrice = await _catalogStatisticService.GetMaxPriceProductPrice();
            var lastProductName = await _catalogStatisticService.LastInsertedProductName();


            var userCount = await _userStatisticService.GetUserAllCountAsync();

            var productId = await _commentStatisticService.MostCommentProductId();
            if (productId != null)
            {
                var result = await _productService.GetProductNameByProductId(productId);
                string value = result.ProductName;
                if (result.ProductName.Length > 30)
                {
                    value = value.Substring(0, value.Substring(0, 30).LastIndexOf(" ")) + "...";
                }
                ViewBag.ProductName = value;

            }
            else
            {
                ViewBag.ProductName = "-";
            }


            var activeCommentCount = await _commentStatisticService.GetActiveCommentCountAsync();
            var passiveCommentCount = await _commentStatisticService.GetPassiveCommentCountAsync();
            var totalCommentCount = await _commentStatisticService.GetAllCommentCountAsync();

            var discountCount = await _discountStatisticService.GetDiscountCouponCountAsync();

            var allMessageService = await _messageService.GetAllMessageCountAsync();


            ViewBag.BrandCount = brandCount;
            ViewBag.CategoryCount = categoryCount;

            ViewBag.ProductCount = productCount;
            ViewBag.AvgProductCount = avgProductCount;
            ViewBag.MaxPriceProductName = maxPriceProductName;
            ViewBag.MinPriceProductName = minPriceProductName;
            ViewBag.MinPrice = minPrice;
            ViewBag.MaxPrice = maxPrice;
            ViewBag.LastProductName = lastProductName;
          

            ViewBag.UserCount = userCount;

            ViewBag.ActiveCommentCount = activeCommentCount;
            ViewBag.TotalCommentCount = totalCommentCount;
            ViewBag.PassiveCommentCount = passiveCommentCount;

            ViewBag.DiscountCount = discountCount;

            ViewBag.AllMessageService = allMessageService;


            return View();
        }
    }
}
