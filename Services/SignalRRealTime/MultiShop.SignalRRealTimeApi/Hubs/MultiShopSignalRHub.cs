using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services.CommentServices;
using MultiShop.SignalRRealTimeApi.Services.MessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class MultiShopSignalRHub : Hub
    {
        private readonly ISignalRMessageService _signalRMessageService;
        private readonly ISignalRCommentService _signalRCommentService;

        public MultiShopSignalRHub(ISignalRMessageService signalRMessageService, ISignalRCommentService signalRCommentService)
        {
            _signalRMessageService = signalRMessageService;
            _signalRCommentService = signalRCommentService;
        }
        public async Task SendStatisticCount(string id)
        {
            var getTotalCommentCount = await _signalRCommentService.TotalCommentAsync();
            await Clients.All.SendAsync("ReciveCommentCount", getTotalCommentCount);

            var getTotalMessageCount = await _signalRMessageService.GetTotalMessageCountByReciverIdAsync(id);
            await Clients.All.SendAsync("ReciveMessageCount", getTotalMessageCount);
        }
    }
}
