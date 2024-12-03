using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.IdentityDtos.RegisterDtos;
using MultiShop.WebUI.Services;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly NotificationService _notificationService;
		public RegisterController(IHttpClientFactory httpClientFactory, NotificationService notificationService)
		{
			_httpClientFactory = httpClientFactory;
			_notificationService = notificationService;
		}
		[HttpGet]
		public IActionResult Index()
		{
			ViewBag.PageTitle = "Hakkımızda  İşlemleri";
			ViewBag.v4 = "Ana Sayfa";
			ViewBag.v5 = "Hakkımızda alanı";
			ViewBag.v6 = "Hakkımızda ekleme";

			ViewBag.i1 = "fa-home";
			ViewBag.i2 = "fa-envelope-o";
			ViewBag.i3 = "fa-bars";

			return View();

		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
		{
			if (createRegisterDto.Password == createRegisterDto.ConfirmPassword)
			{
				var client = _httpClientFactory.CreateClient();
				var data = JsonConvert.SerializeObject(createRegisterDto);
				StringContent str = new StringContent(data, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("http://localhost:5001/api/Registers", str);
				if (responseMessage.IsSuccessStatusCode)
				{
					_notificationService.Success("Yeni kayıt eklendi.");
					return RedirectToAction("Index", "Login");
				}
				else
				{
					_notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
				}
			}
			else
			{
				_notificationService.Error("Şifreler eşleşmiyor");
			}
			
			return RedirectToAction("Index");

		}
	}
}
