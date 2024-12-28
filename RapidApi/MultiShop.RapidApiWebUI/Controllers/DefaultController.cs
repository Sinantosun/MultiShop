using Microsoft.AspNetCore.Mvc;
using MultiShop.RapidApiWebUI.Models;
using Newtonsoft.Json;

namespace MultiShop.RapidApiWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public async Task<IActionResult> Index()
        {

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://yahoo-weather5.p.rapidapi.com/weather?location=kocaeli&format=json&u=c"),
                Headers =
    {
        { "x-rapidapi-key", "rapid api key" },
        { "x-rapidapi-host", "yahoo-weather5.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ResultWeatherModel>(body);
                ViewBag.CityTemp = data.current_observation.condition.temperature;


            }
            return View();
        }


        public async Task<IActionResult> ExchangePage()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=USD&to_symbol=TRY&language=TR"),
                Headers =
    {
        { "x-rapidapi-key", "rapid api key" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                ViewBag.exchangeRate = model.data.exchange_rate;
         
            }



            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://real-time-finance-data.p.rapidapi.com/currency-exchange-rate?from_symbol=EUR&to_symbol=TRY&language=TR"),
                Headers =
    {
        { "x-rapidapi-key", "rapid api key" },
        { "x-rapidapi-host", "real-time-finance-data.p.rapidapi.com" },
    },
            };
            using (var response2 = await client2.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                var model2 = JsonConvert.DeserializeObject<ExchangeViewModel>(body2);
                ViewBag.exchangeEuro = model2.data.exchange_rate;

            }


            return View();
        }
    }
}
