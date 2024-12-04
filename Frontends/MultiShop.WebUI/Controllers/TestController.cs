using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.Concrete;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

namespace MultiShop.WebUI.Controllers
{
    public class TestController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly NotificationService _notificationService;
        public TestController(IHttpClientFactory httpClientFactory, NotificationService notificationService)
        {
            _httpClientFactory = httpClientFactory;
            _notificationService = notificationService;
        }

        public async Task<IActionResult> Index()
        {
            string token = "";
            using (var httclient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("http://localhost:5001/connect/token"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string>
                    {
                        {
                            "client_id","MultiShopVisitorId"
                        },
                        {
                            "client_secret","multishopsecret"
                        },
                        {
                            "grant_type","client_credentials"
                        }
                    })
                };

                using(var response = await httclient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var tokenResponse = JObject.Parse(content);
                        token = tokenResponse["access_token"].ToString();
                    }
                }
            }

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(result);
            }
            return View(new List<ResultCategoryDto>());
        }
    }
}
