using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderingServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MyOrdersController : Controller
    {
        private readonly IOrderingService _orderingService;
        private readonly IUserService _userService;
        public MyOrdersController(IOrderingService orderingService, IUserService userService)
        {
            _orderingService = orderingService;
            _userService = userService;
        }

        public async Task<IActionResult> MyOrderList()
        {
            var userInfo = await _userService.GetUserInfoAsync();
            var values = await _orderingService.GetOrderingByUserId(userInfo.Id);
            return View(values);
        }
    }
}
