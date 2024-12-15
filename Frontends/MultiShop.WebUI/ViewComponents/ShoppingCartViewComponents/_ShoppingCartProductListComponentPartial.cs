using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.BasketDtos;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartProductListComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;
        private readonly NotificationService _notificationService;
        public _ShoppingCartProductListComponentPartial(IBasketService basketService, NotificationService notificationService)
        {
            _basketService = basketService;
            _notificationService = notificationService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasket();
            if (values.Message != "Unauthorized")
            {
                return View(values);
            }
            else
            {
                _notificationService.Error("İşleminize devam edebilmek için giriş yapmalısınız.");
                TempData["UserLoginStatus"] = "Unauthorized";
                return View(new BasketTotalDto());
            }

        }
    }
}
