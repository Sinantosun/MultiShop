namespace MultiShop.SignalRRealTimeApi.Services.MessageServices
{
    public interface ISignalRMessageService
    {
        Task<int> GetTotalMessageCountByReciverIdAsync(string id);
    }
}
