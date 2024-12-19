using MultiShop.DtoLayer.Dtos.MessageDtos;

namespace MultiShop.WebUI.Services.MessasgeServices
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetMessageListAsync();
        Task<bool> CreateMessageAsync(CreateMessageDto createMessageDto);
        Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id);
        Task<bool> DeleteMessageAsync(int id);
        Task<bool> UpdateMessageAsync(UpdateMessageDto updateMessageDto);

        Task<GetByIdMessageByIdDto> GetMessageByIdAsync(int id);
    }
}
