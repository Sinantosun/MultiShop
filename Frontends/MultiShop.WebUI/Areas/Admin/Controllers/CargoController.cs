using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServcies.CargoCompanyServices;
using MultiShop.WebUI.Services.Concrete;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly NotificationService _notificationService;

        public CargoController(NotificationService notificationService, ICargoCompanyService cargoCompanyService)
        {
            _notificationService = notificationService;
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task<IActionResult> CargoList()
        {

            ViewBag.PageTitle = "Kargo  İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Kargo alanı";
            ViewBag.v6 = "Kargo Şirketleri listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";


            var values = await _cargoCompanyService.GetAllCargoAsync();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateCargoCompany()
        {
            ViewBag.PageTitle = "Kargo  İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Kargo alanı";
            ViewBag.v6 = "Yeni Kargo Şirketi Ekleme Sayfası";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoDto createCargoDto)
        {
            var result = await _cargoCompanyService.CreateCargoAsync(createCargoDto);
            if (result)
            {
                _notificationService.Success("Kargo şirketi eklendi");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında beklenmeyen bir hata meydana geldi.");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
           
            ViewBag.PageTitle = "Kargo  İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Kargo alanı";
            ViewBag.v6 = "Kargo Şirketi Güncelleme Sayfası";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var values = await _cargoCompanyService.GetCargoByIdAsync(id);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoDto updateCargoDto)
        {
            var result = await _cargoCompanyService.UpdateCargoAsync(updateCargoDto);
            if (result)
            {
                _notificationService.Success("Kargo şirketi güncellendi");
            }
            else
            {
                _notificationService.Error("Kayıt güncelleme sırasında beklenmeyen bir hata meydana geldi.");
            }

            return RedirectToAction("CargoList");
        }


        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            bool result = await _cargoCompanyService.DeleteCargoAsync(id);
            if (result)
            {
                _notificationService.Success("Kayıt Silindi");
            }
            else
            {
                _notificationService.Error("Bir Hata Oluştu");
            }
            return RedirectToAction("CargoList");
        }
    }
}
