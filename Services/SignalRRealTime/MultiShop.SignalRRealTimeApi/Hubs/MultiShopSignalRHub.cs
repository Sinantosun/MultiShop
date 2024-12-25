using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRRealTimeApi.Services.CommentServices;
using MultiShop.SignalRRealTimeApi.Services.MessageServices;

namespace MultiShop.SignalRRealTimeApi.Hubs
{
    public class MultiShopSignalRHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;

        public MultiShopSignalRHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }
        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _signalRCommentService.TotalCommentAsync();
            await Clients.All.SendAsync("ReciveCommentCount", getTotalCommentCount);


        }
    }
}
