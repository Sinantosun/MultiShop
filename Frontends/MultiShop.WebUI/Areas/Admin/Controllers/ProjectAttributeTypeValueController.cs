using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductAttributeTypeDtos;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ProductAttributeTypeValueDtos;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.ProjectAttributeTypeValue;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class ProjectAttributeTypeValueController : Controller
    {
        private readonly IProjectAttributeTypeValueService _projectAttributeTypeValueService;
        private readonly NotificationService _notificationService;
        private readonly IProductService _productService;
        public ProjectAttributeTypeValueController(IProjectAttributeTypeValueService projectAttributeTypeValueService, NotificationService notificationService, IProductService productService)
        {
            _projectAttributeTypeValueService = projectAttributeTypeValueService;
            _notificationService = notificationService;
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> Index(string id = "67716dc83e6b9fcf5c5c709c")
        {
            var value = await _productService.GetProductNameByProductId(id);

            var values = await _projectAttributeTypeValueService.GetProductAttributeTypeValueByProductIdAsync();

            ViewBag.PageTitle = value.ProductName + " - Özellik Atama Sayfası";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ürünler alanı";
            ViewBag.v6 = value.ProductName + " - Özellik Atama Sayfası";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            return View(values);

        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateProductAttributeTypeValueDto createProjectAttributeTypeValueDto)
        {
            await _projectAttributeTypeValueService.CreateProductAttributeTypeValueAsync(createProjectAttributeTypeValueDto);

            _notificationService.Success("Yeni kayıt eklendi.");

            return RedirectToAction("CreateProjectAttribute");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateProjectAttribute(string id)
        {
            ViewBag.PageTitle = "Ürün İşlemleri";
            ViewBag.v4 = "Ana Sayfa";
            ViewBag.v5 = "Ürünler alanı";
            ViewBag.v6 = "Ürünler Özellik Güncelleme Sayfası";

            ViewBag.i1 = "fa-home";
            ViewBag.i2 = "fa-envelope-o";
            ViewBag.i3 = "fa-bars";

            var result = await _projectAttributeTypeValueService.GetProductAttributeTypeValueByIdAsync(id);
            if (result != null)
            {
                return View(result);
            }
            _notificationService.Error("Beklenmeyen bir hata meydana geldi.");
            return View(new ResultProductAttributeTypeByIdDto());
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProjectAttribute(UpdateProductAttributeTypeValueDto updateProjectAttributeTypeValueDto)
        {
            await _projectAttributeTypeValueService.UpdateProductAttributeTypeValueAsync(updateProjectAttributeTypeValueDto);

            _notificationService.Success("Kayıt güncellendi.");
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> DeleteProjectAttribute(string id)
        {
            await _projectAttributeTypeValueService.DeleteProductAttributeTypeValueAsync(id);

            _notificationService.Success("Kayıt silindi.");

            return RedirectToAction("Index");

        }
    }
}


