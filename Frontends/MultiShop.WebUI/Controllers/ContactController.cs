using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Services;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly NotificationService _notificationService;
        private readonly IHttpClientFactory _httpClientFactory;
        public ContactController(NotificationService notificationService, IHttpClientFactory httpClientFactory)
        {
            _notificationService = notificationService;
            _httpClientFactory = httpClientFactory;
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
            contact.SendDate = DateTime.Now;
            contact.IsRead = false;
            var client = _httpClientFactory.CreateClient();
            var data = JsonConvert.SerializeObject(contact);
            StringContent content = new StringContent(data,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/Contacts", content);
            if (responseMessage.IsSuccessStatusCode)
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
