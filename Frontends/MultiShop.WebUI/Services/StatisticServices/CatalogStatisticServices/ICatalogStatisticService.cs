namespace MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices
{
    public interface ICatalogStatisticService
    {
        Task<int> GetCategoryCount();
        Task<int> GetBrandCount();
        Task<int> GetProductCount();
        Task<decimal> GetProductAvgPrice();

       Task<string> GetMaxPriceProductName();
       Task<string> GetMinPriceProductName();

        Task<decimal> GetMaxPriceProductPrice();

        Task<decimal> GetMinPriceProductPrice();
        Task<string> LastInsertedProductName();

    }
}
