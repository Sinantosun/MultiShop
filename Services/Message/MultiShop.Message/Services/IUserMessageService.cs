using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetMessageListAsync();
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
        Task DeleteMessageAsync(int id);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);

        Task<GetByIdMessageByIdDto> GetMessageByIdAsync(int id);
    }
}
