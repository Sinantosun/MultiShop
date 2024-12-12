using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;
        private readonly NotificationService _notificationService;
        public SpecialOfferController(NotificationService notificationService, ISpecialOfferService specialOfferService)
        {
            _notificationService = notificationService;
            _specialOfferService = specialOfferService;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.PageTitle = "Özel Teklif Alanı";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Özel Teklifler";
            ViewBag.v6 = "Özel Teklif Listesi";


            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            if (values != null)
            {

                return View(values);
            }
            return View(new List<ResultSpecialOfferDto>());
        }

        [HttpGet]
        public IActionResult CreateSpecialOffer()
        {
            ViewBag.PageTitle = "Özel Teklif Alanı";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Özel Teklifler";
            ViewBag.v6 = "Özel Teklif Listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            bool result = await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            if (result)
            {
                _notificationService.Success("Yeni kayıt eklendi.");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
            }
            return RedirectToAction("CreateSpecialOffer");

        }


        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            ViewBag.PageTitle = "Özel Teklif Alanı";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Özel Teklifler";
            ViewBag.v6 = "Özel Teklif Listesi";


            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var value = await _specialOfferService.GetSpecialOfferByIdAsync(id);
            if (value != null)
            {
                return View(value);
            }
            _notificationService.Error("Beklenmeyen bir hata meydana geldi.");
            return View(new ResultSpecialOfferByIdDto());


        }
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            bool result = await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
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


        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            bool result = await _specialOfferService.DeleteSpecialOfferAsync(id);
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
