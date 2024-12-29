using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductAttributeTypeDtos;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.ProjectAttrubiteTypes;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProductAttributeTypeController : Controller
    {
        private readonly IProductAttrubiteTypeService _productAttrubiteTypeService;
        private readonly NotificationService _notificationService;
        public ProductAttributeTypeController(NotificationService notificationService, IProductAttrubiteTypeService productAttrubiteTypeService)
        {
            _notificationService = notificationService;
            _productAttrubiteTypeService = productAttrubiteTypeService;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.PageTitle = "Ürün Özellik İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ürünler alanı";
            ViewBag.v6 = "Ürün özellik listesi";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var values = await _productAttrubiteTypeService.GetAllProductAttributeTypeAsync();
            if (values != null)
            {
                return View(values);

            }
            return View(new List<ResultProductAttributeTypeDto>());



        }

        [HttpGet]
        public IActionResult CreateProductAttribute()
        {
            ViewBag.PageTitle = "Ürün Özellik İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ürünler alanı";
            ViewBag.v6 = "Ürün özellik ekleme sayfası";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> CreateProductAttribute(CreateProductAttributeTypeDto createProductAttributeDto)
        {
            await _productAttrubiteTypeService.CreateProductAttributeTypeAsync(createProductAttributeDto);
            _notificationService.Success("Yeni kayıt eklendi.");
            return RedirectToAction("CreateProductAttribute");

        }


        [HttpGet]
        public async Task<IActionResult> UpdateProductAttribute(string id)
        {
            ViewBag.PageTitle = "Ürün Özellik İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ürünler alanı";
            ViewBag.v6 = "Ürün özellik güncelleme";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var result = await _productAttrubiteTypeService.GetProductAttributeTypeByIdAsync(id);
            if (result != null)
            {
                return View(result);
            }

            _notificationService.Error("Beklenmeyen bir hata meydana geldi.");
            return View(new ResultProductAttributeTypeByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProductAttribute(UpdateProductAttributeTypeDto updateProductAttributeDto)
        {
            await _productAttrubiteTypeService.UpdateProductAttributeTypeAsync(updateProductAttributeDto);
            _notificationService.Success("Yeni kayıt Güncellendi.");
            return RedirectToAction("CreateProductAttribute");

        }

        public async Task<IActionResult> DeleteProductAttribute(string id)
        {
            await _productAttrubiteTypeService.DeleteProductAttributeTypeAsync(id);

            return RedirectToAction("Index");
        }
    }
}
