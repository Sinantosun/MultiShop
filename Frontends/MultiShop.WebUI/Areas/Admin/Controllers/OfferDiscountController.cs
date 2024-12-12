using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.OfferDiscountDtos;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class OfferDiscountController : Controller
    {

        private readonly NotificationService _notificationService;
        private readonly IOfferDiscountService _offerDiscountService;
        public OfferDiscountController(NotificationService notificationService, IOfferDiscountService offerDiscountService)
        {

            _notificationService = notificationService;
            _offerDiscountService = offerDiscountService;
        }
        public async Task<IActionResult> Index()
        {

            ViewBag.PageTitle = "Ana Sayfa İndirim İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ana Sayfa İndirimler";
            ViewBag.v6 = "Ana Sayfa İndirim Listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var value = await _offerDiscountService.GetAllOfferDiscountAsync();
            if (value != null)
            {
                return View(value);
            }
            return View(new List<ResultOfferDiscountDto>());
        }

        [HttpGet]
        public IActionResult CreateOfferDiscount()
        {
            ViewBag.PageTitle = "Ana Sayfa İndirim İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ana Sayfa İndirimler";
            ViewBag.v6 = "Ana Sayfa İndirim Ekle";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";


            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateOfferDiscount(CreateOfferDiscountDto createOfferDiscountDto)
        {
            bool result = await _offerDiscountService.CreateOfferDiscountAsync(createOfferDiscountDto);
            if (result)
            {
                _notificationService.Success("Yeni kayıt eklendi.");
                return RedirectToAction("Index");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
                return RedirectToAction("CreateOfferDiscount");
            }

        }


        [HttpGet]
        public async Task<IActionResult> UpdateOfferDiscount(string id)
        {
            ViewBag.PageTitle = "Ana Sayfa İndirim İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ana Sayfa İndirimler";
            ViewBag.v6 = "Ana Sayfa İndirim Güncelle";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var value = await _offerDiscountService.GetOfferDiscountByIdAsync(id);
            if (value != null)
            {
                return View(value);
            }
            return View(new ResultOfferDiscountByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateOfferDiscount(UpdateOfferDiscountDto updateOfferDiscountDto)
        {
            bool result = await _offerDiscountService.UpdateOfferDiscountAsync(updateOfferDiscountDto);
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


        public async Task<IActionResult> DeleteOfferDiscount(string id)
        {
            bool result = await _offerDiscountService.DeleteOfferDiscountAsync(id);
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

