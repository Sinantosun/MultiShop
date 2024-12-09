using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.Interfaces;

namespace MultiShop.WebUI.Container
{
    public static class LifeTimeConfigurations
    {
        public static void AddScopedConfiguration(this IServiceCollection services)
        {
            services.AddScoped<NotificationService>();
            services.AddScoped<ILoginService, LoginService>();

            services.AddScoped<ResourceOwnerPasswordTokenHandler>();
            services.AddScoped<ClientCredentialTokenHandler>();
        }
    }
}
