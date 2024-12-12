using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.BrandDtos;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        private readonly NotificationService _notificationService;
        public BrandController(NotificationService notificationService, IBrandService brandService)
        {
            _notificationService = notificationService;
            _brandService = brandService;
        }


        public async Task<IActionResult> Index()
        {
            var values = await _brandService.GetAllBrandAsync();
            ViewBag.PageTitle = "Markalar Alan İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Markalar alanlar";
            ViewBag.v6 = "Markalar alan listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            if (values != null)
            {
                return View(values);
            }
            return View(new List<ResultBrandDto>());
        }

        [HttpGet]
        public IActionResult CreateBrand()
        {
            ViewBag.PageTitle = "Markalar Alan İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Markalar alanlar";
            ViewBag.v6 = "Marka ekleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createbrandDto)
        {
            bool result = await _brandService.CreateBrandAsync(createbrandDto);
            if (result)
            {
                _notificationService.Success("Yeni kayıt eklendi.");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
            }
            return RedirectToAction("Createbrand");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.PageTitle = "Markalar Alan İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Markalar alanlar";
            ViewBag.v6 = "Marka güncelleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var result = await _brandService.GetBrandByIdAsync(id);
            if (result != null)
            {
                return View(result);
            }
            _notificationService.Error("Beklenmeyen bir hata meydana geldi.");
            return View(new ResultBrandByIdDto());
            
        }
        [HttpPost]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updatebrandDto)
        {
            bool result = await _brandService.UpdateBrandAsync(updatebrandDto);
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


        public async Task<IActionResult> Deletebrand(string id)
        {
            bool result = await _brandService.DeleteBrandAsync(id);
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
