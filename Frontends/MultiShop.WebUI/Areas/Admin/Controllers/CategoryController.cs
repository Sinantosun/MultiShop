using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class CategoryController : Controller
    {
        private readonly NotificationService _notificationService;
        private readonly ICategoryService _categoryService;
        public CategoryController(NotificationService notificationService, ICategoryService categoryService)
        {
            _notificationService = notificationService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Kategori İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Kategoriler";
            ViewBag.v6 = "Kategori Listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i2 = "fa-bars";

            var values = await _categoryService.GetAllCategoryAsync();
            if (values != null)
            {
                return View(values);

            }
            return View(new List<ResultCategoryDto>());
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            ViewBag.PageTitle = "Kategori İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Kategoriler";
            ViewBag.v6 = "Kategori Ekle";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i2 = "fa-bars";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            bool result = await _categoryService.CreateCategoryAsync(createCategoryDto);
            if (result)
            {
                _notificationService.Success("Yeni kayıt eklendi.");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
            }
            return RedirectToAction("CreateCategory");

        }


        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            ViewBag.PageTitle = "Kategori İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Kategoriler";
            ViewBag.v6 = "Kategori Güncelle";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i2 = "fa-bars";


            var value = await _categoryService.GetCategoryByIdAsync(id);
            if (value != null)
            {
                return View(value);
            }
            return View(new ResultCategoryByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var result = await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            if (result)
            {
                _notificationService.Success("Kayıt güncellendi.");
                return RedirectToAction("Index");
            }
            _notificationService.Error("Kayıt güncelleme sırasında bir hata oluştu.");
            return View();

        }


        public async Task<IActionResult> DeleteCategory(string id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
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
