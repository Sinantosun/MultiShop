using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.MessasgeServices;

namespace MultiShop.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class MessageController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserMessageService _messageService;

        public MessageController(IUserService userService, IUserMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public async Task<IActionResult> Inbox()
        {
            var user = await _userService.GetUserInfoAsync();
            var result = await _messageService.GetInboxMessageAsync(user.Id);
            return View(result);
        }

        public async Task<IActionResult> SendBox()
        {
            var user = await _userService.GetUserInfoAsync();
            var result = await _messageService.GetSendboxMessageAsync(user.Id);
            return View(result);
        }
    }
}
