using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MultiShop.WebUI.Container
{
    public static class AuthenticationConfigurations
    {
        public static void AddAuthenticationSettings(this IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opts =>
            {
                opts.LoginPath = "/Login/Index";
                opts.LogoutPath = "/Login/LogOut";
                opts.AccessDeniedPath = "/Pages/AccsessDenied";
                opts.Cookie.HttpOnly = true;
                opts.Cookie.SameSite = SameSiteMode.Strict;
                opts.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                opts.Cookie.Name = "MultiShopJwt";
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
            {
                opt.LoginPath = "/Login/Index";
                opt.ExpireTimeSpan = TimeSpan.FromDays(5);
                opt.Cookie.Name = "MultiShopCookie";
                opt.SlidingExpiration = true;

            });
        }
    }
}
