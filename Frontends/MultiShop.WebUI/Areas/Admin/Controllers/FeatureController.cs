using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.FeatureDtos;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FeatureController : Controller
    {
        private readonly NotificationService _notificationService;
        private readonly IFeatureService _featureService;
        public FeatureController(NotificationService notificationService, IFeatureService featureService)
        {
            _notificationService = notificationService;
            _featureService = featureService;
        }


        public async Task<IActionResult> Index()
        {

            ViewBag.PageTitle = "Öne Çıkan Alan İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Öne çıkan alanlar";
            ViewBag.v6 = "Öne çıkan alan listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var values = await _featureService.GetAllFeatureAsync();
            if (values != null)
            {
                return View(values);
            }
            return View(new List<ResultFeatueDto>());
        }

        [HttpGet]
        public IActionResult CreateFeature()
        {
            ViewBag.PageTitle = "Öne Çıkan Alan İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Öne çıkan alanlar";
            ViewBag.v6 = "Öne çıkan alan ekleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            bool result = await _featureService.CreateFeatureAsync(createFeatureDto);
            if (result)
            {
                _notificationService.Success("Yeni kayıt eklendi.");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
            }
            return RedirectToAction("CreateFeature");

        }


        [HttpGet]
        public async Task<IActionResult> UpdateFeature(string id)
        {
            ViewBag.PageTitle = "Öne Çıkan Alan İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Öne çıkan alanlar";
            ViewBag.v6 = "Öne çıkan alan güncelleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var value = await _featureService.GetFeatureByIdAsync(id);
            if (value != null)
            {
                return View(value);
            }
            _notificationService.Error("Beklenmeyen bir hata meydana geldi.");
            return View(new ResultFeatureByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            bool result = await _featureService.UpdateFeatureAsync(updateFeatureDto);
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


        public async Task<IActionResult> DeleteFeature(string id)
        {
            bool result = await _featureService.DeleteFeatureAsync(id);
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
