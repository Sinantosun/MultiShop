using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductController : Controller
    {
        private readonly NotificationService _notificationService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public ProductController(NotificationService notificationService, ICategoryService categoryService, IProductService productService)
        {
            _notificationService = notificationService;
            _categoryService = categoryService;
            _productService = productService;
        }

        async Task<bool> SetCategorySelectoption()
        {
            var result = await _categoryService.GetAllCategoryAsync();
            if (result != null)
            {
                List<SelectListItem> values = (from x in result
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.Id,
                                               }).ToList();
                ViewBag.categoryvalues = values;
                return true;
            }
            return false;

        }


        public async Task<IActionResult> Index()
        {
            ViewBag.PageTitle = "Ürün İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ürünler";
            ViewBag.v6 = "Ürün Listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var result = await _productService.GetProductWithCategoriesAsync();
            if (result != null)
            {
                return View(result);
            }
            return View(new List<ResultProductWithCategoriesDto>());

        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            ViewBag.PageTitle = "Ürün İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ürünler";
            ViewBag.v6 = "Ürün Ekle";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            bool checkresponse = await SetCategorySelectoption();
            if (checkresponse)
            {
                return View();
            }
            _notificationService.Error("Beklenmeyen bir hata meydana geldi.");
            return RedirectToAction("Index");

        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            var result = await _productService.CreateProductAsync(createProductDto);
            if (result)
            {
                _notificationService.Success("Yeni kayıt eklendi.");
            }
            else
            {
                _notificationService.Error("Kayıt ekleme sırasında bir hata oluştu.");
            }

            return RedirectToAction("CreateProduct");

        }


        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string id)
        {
            ViewBag.PageTitle = "Ürün İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ürünler";
            ViewBag.v6 = "Ürün Güncelle";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var result = await _productService.GetProductByIdAsync(id);
            if (result != null)
            {
                var categoryresult = await SetCategorySelectoption();
                if (categoryresult)
                {
                    return View(result);
                }
            }
            _notificationService.Error("Beklenmeyen bir hata meydana geldi.");
            return View(new ResultProductByIdDto());

        }
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            var result = await _productService.UpdateProductAsync(updateProductDto);
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


        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _productService.DeleteProductAsync(id);
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
