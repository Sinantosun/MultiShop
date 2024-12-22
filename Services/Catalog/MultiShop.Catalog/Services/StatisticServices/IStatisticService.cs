namespace MultiShop.Catalog.Services.StatisticServices
{
    public interface IStatisticService
    {
        int GetCategoryCount();
        int GetBrandCount();
        int GetProductCount();
        decimal GetProductAvgPrice();

        string GetMaxPriceProductName();

        decimal GetMaxPriceProductPrice();

        decimal GetMinPriceProductPrice();

        string GetMinPriceProductName();


        string LastInsertedProductName();






       
    }
}
