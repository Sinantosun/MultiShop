using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.Dtos.IdentityDtos.LoginDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginService _loginService;
		public LoginController(IHttpClientFactory httpClientFactory, ILoginService loginService)
		{
			_httpClientFactory = httpClientFactory;
			_loginService = loginService;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(LoginDto logindto)
		{
			
			var client = _httpClientFactory.CreateClient();
			var content = new StringContent(JsonSerializer.Serialize(logindto), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("http://localhost:5001/api/Logins", content);
			if (response.IsSuccessStatusCode)
			{
				var jsondata = await response.Content.ReadAsStringAsync();
				var tokenmodel = JsonSerializer.Deserialize<JwtResponseModel>(jsondata, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,

				});

				if (tokenmodel != null)
				{
					JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
					var token = handler.ReadJwtToken(tokenmodel.Token);
					var claims = token.Claims.ToList();

					if (tokenmodel.Token != null)
					{
						claims.Add(new Claim("multishoptoken",tokenmodel.Token));
						var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
						var authProprs = new AuthenticationProperties
						{
							ExpiresUtc = tokenmodel.ExpireDate,
							IsPersistent = true,
						};

						await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity),authProprs);
						var id = _loginService.GetUserId;
						return RedirectToAction("Index", "Default");
					}
				}
			}
			return View();
		}
	}
}
