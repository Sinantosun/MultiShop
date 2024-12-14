using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly NotificationService _notificationService;
        private readonly IContactService _contactService;
        public ContactController(NotificationService notificationService, IContactService contactService)
        {
            _notificationService = notificationService;
            _contactService = contactService;
        }

        public IActionResult Index()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Bize Ulaşın";
            ViewBag.v3 = "İletişim";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendContact(CreateContactDto contact)
        {
            contact.IsRead = false;
            contact.SendDate = DateTime.Now;
            bool result = await _contactService.CreateContactAsync(contact);
            if (result)
            {
                _notificationService.Success("Mesajınız başarıyla gönderildi.");
            }
            else
            {
                _notificationService.Error("Mesajınız iletiminde bir hata meydana geldi mesajaınız gönderilemedi.");
            }
            return RedirectToAction("Index");
        }
    }
}
