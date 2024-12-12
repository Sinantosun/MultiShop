using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureSliderDtos;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FeatureSliderController : Controller
    {
        private readonly NotificationService _notificationService;
        private readonly IFeatureSliderService _featureSliderService;
        public FeatureSliderController(NotificationService notificationService, IFeatureSliderService featureSliderService)
        {
            _notificationService = notificationService;
            _featureSliderService = featureSliderService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Slider İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Slider";
            ViewBag.v6 = "Slider Görselleri";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var values = await _featureSliderService.GetAllFeatureSliderAsync();
            if (values != null)
            {
                return View(values);
            }
            return View(new List<ResultFeatureSliderDto>());
        }

        [HttpGet]
        public IActionResult CreateFeatureSlider()
        {
            ViewBag.PageTitle = "Slider İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Slider";
            ViewBag.v6 = "Slider Ekleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {

            bool result = await _featureSliderService.CreateFeatureSliderAsync(createFeatureSliderDto);
            if (result)
            {
                _notificationService.Success("Kayıt Eklendi");
                return RedirectToAction("Index");
            }
            _notificationService.Error("Bir Hata oluştu lütfen tekrar deneyin");
            return View(createFeatureSliderDto);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFeatureSlider(string id)
        {
            ViewBag.PageTitle = "Slider İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Slider";
            ViewBag.v6 = "Slider Güncelleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var value = await _featureSliderService.GetFeatureSliderByIdAsync(id);
            if (value != null)
            {
                return View(value);
            }
            return View(new ResultFeatureSliderByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeatureSlider(UpdateFeatureSliderDto updateFeatureSliderDto)
        {
            bool result = await _featureSliderService.UpdateFeatureSliderAsync(updateFeatureSliderDto);
            if (result)
            {
                _notificationService.Success("Kayıt Güncellendi");
                return RedirectToAction("Index");
            }
            _notificationService.Error("Bir Hata oluştu lütfen tekrar deneyin");
            return View(updateFeatureSliderDto);
        }


        public async Task<IActionResult> ChangeSliderStatusToTrue(string id)
        {
            bool result = await _featureSliderService.ChangeFeatureSliderStatusToTrue(id);
            if (result)
            {
                _notificationService.Success("Slider yayına alındı");
                return RedirectToAction("Index");
            }
            _notificationService.Error("Slider yayına alınırken bir sorun oluştu lütfen tekarar deneyin.");
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> ChangeSliderStatusToFalse(string id)
        {
            bool result = await _featureSliderService.ChangeFeatureSliderStatusToFalse(id);
            if (result)
            {
                _notificationService.Success("Slider yayından kaldırıldı");
                return RedirectToAction("Index");
            }
            _notificationService.Error("Slider yayına alınırken bir sorun oluştu lütfen tekarar deneyin.");
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> DeleteFeatureSlider(string id)
        {
            bool result = await _featureSliderService.DeleteFeatureSliderAsync(id);
            if (result)
            {
                _notificationService.Success("Slider kaydı silindi");
                return RedirectToAction("Index");
            }
            _notificationService.Error("Slider kaydi silinemedi bir hata oluştu ");
            return RedirectToAction("Index");
        }

    }
}
