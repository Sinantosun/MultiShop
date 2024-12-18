using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.OrderAddressDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAdressService _orderAdressService;
        private readonly IUserService _userService;
        public OrderController(IOrderAdressService orderAdressService, IUserService userService)
        {
            _orderAdressService = orderAdressService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Siparişler";
            ViewBag.v3 = "Sipariş İşlemleri";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddOrderAddress(CreateOrderAddressDto createOrderAddressDto)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Siparişler";
            ViewBag.v3 = "Sipariş İşlemleri";
            var values = await _userService.GetUserInfoAsync();

            createOrderAddressDto.UserId = values.Id;
            createOrderAddressDto.Description = "test";

            bool result = await _orderAdressService.CreateOrderAddressAsync(createOrderAddressDto);
            if (result)
            {
                return RedirectToAction("Index", "Payment");
            }
            return View();
        }
    }
}
