using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.AboutDtos;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        private readonly NotificationService _notificationService;
        public AboutController(NotificationService notificationService, IAboutService aboutService)
        {

            _notificationService = notificationService;
            _aboutService = aboutService;
        }


        public async Task<IActionResult> Index()
        {

            ViewBag.PageTitle = "Hakkımızda  İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Hakkımızda alanı";
            ViewBag.v6 = "Hakkımızda listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";


            var value = await _aboutService.GetAllAboutAsync();
            if (value != null)
            {
                return View(value);
            }
            return View(new List<ResultAboutDto>());
        }

        [HttpGet]
        public IActionResult CreateAbout()
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
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            bool result = await _aboutService.CreateAboutAsync(createAboutDto);
            if (result)
            {
                _notificationService.Success("Yeni kayıt eklendi.");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
            }
            return RedirectToAction("CreateAbout");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateAbout(string id)
        {
            ViewBag.PageTitle = "Hakkımızda İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Hakkımızda alanı";
            ViewBag.v6 = "Hakkımızda güncelleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var result = await _aboutService.GetAboutByIdAsync(id);
            if (result != null)
            {
                return View(result);
            }
            _notificationService.Error("Beklenmeyen bir hata meydana geldi.");
            return View(new ResultAboutByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            bool result = await _aboutService.UpdateAboutAsync(updateAboutDto);
            if (result)
            {
                _notificationService.Success("Kayıt güncellendi.");
                return RedirectToAction("Index");
            }
            else
            {
                _notificationService.Error("Kayıt güncelleme sırasında bir hata oluştu.");
            }

            return View();

        }

        public async Task<IActionResult> DeleteAbout(string id)
        {
            bool result = await _aboutService.DeleteAboutAsync(id);
            if (result)
            {
                _notificationService.Success("Kayıt silindi.");
            }
            else
            {
                _notificationService.Error("Kayıt silme esnasında bir hata oluştu.");
            }
            return RedirectToAction("Index");
          
        }
    }
}
