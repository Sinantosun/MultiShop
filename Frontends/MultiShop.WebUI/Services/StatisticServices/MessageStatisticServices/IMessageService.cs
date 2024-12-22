namespace MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices
{
    public interface IMessageService
    {
        Task<int> GetAllMessageCountAsync();
    }
}
