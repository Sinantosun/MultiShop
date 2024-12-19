using MultiShop.Catalog.Services.ProductServices;
using MultiShop.WebUI.Handlers;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.AboutServices;
using MultiShop.WebUI.Services.CatalogServices.BrandServices;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureServices;
using MultiShop.WebUI.Services.CatalogServices.FeatureSliderServices;
using MultiShop.WebUI.Services.CatalogServices.OfferDiscountServices;
using MultiShop.WebUI.Services.CatalogServices.ProductDetailServices;
using MultiShop.WebUI.Services.CatalogServices.ProductImageServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.Concrete;
using MultiShop.WebUI.Services.DiscountServices;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessasgeServices;
using MultiShop.WebUI.Services.OrderServices.OrderAddressServices;
using MultiShop.WebUI.Services.OrderServices.OrderingServices;
using MultiShop.WebUI.Settings;
using System.Configuration;

namespace MultiShop.WebUI.Container
{
    public static class HttpClientConfigurations
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            var values = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();


            #region Catalog
            services.AddHttpClient<IUserService, UserService>(opts =>
            {
                opts.BaseAddress = new Uri(values.IdentityServerUrl);
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IBasketService, BasketService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Basket.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IOrderAdressService, OrderAdressService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IOrderingService, OrderingService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IUserMessageService, UserMessageService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.UserMessage.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<IDiscountService, DiscountService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
            }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

            services.AddHttpClient<ICategoryService, CategoryService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductService, ProductService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();


            services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IFeatureService, FeatureService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");

            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IOfferDiscountService, OfferDisocuntService>(opts =>
            {
            opts.BaseAddress = new Uri($"{values.OcelotUrl}/{ values.Catalog.Path }");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IBrandService, BrandService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IAboutService, AboutService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductImageService, ProductImageService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IProductDetailService, ProductDetailService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            services.AddHttpClient<IContactService, ContactService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

            #endregion

            #region Comment
            services.AddHttpClient<ICommentService, CommentService>(opts =>
            {
                opts.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");
            }).AddHttpMessageHandler<ClientCredentialTokenHandler>();
            #endregion

            services.AddHttpClient();
            services.AddHttpClient<IIdentityService, IdentityService>();
            services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();
        }

    }
}
