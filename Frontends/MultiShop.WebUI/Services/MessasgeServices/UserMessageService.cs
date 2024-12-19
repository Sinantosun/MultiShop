using MultiShop.DtoLayer.Dtos.MessageDtos;

namespace MultiShop.WebUI.Services.MessasgeServices
{
    public class UserMessageService : IUserMessageService
    {
        private readonly HttpClient _httpClient;

        public UserMessageService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateMessageDto>("UserMessage", createMessageDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"UserMessage?id={id}");
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultInboxMessageDto>>($"UserMessage/GetMessageInbox/{id}");
            return response;
          
        }

        public async Task<GetByIdMessageByIdDto> GetMessageByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<GetByIdMessageByIdDto>($"UserMessage/{id}");
            return response;
        }

        public async Task<List<ResultMessageDto>> GetMessageListAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultMessageDto>>("UserMessage");
            return response;
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultSendboxMessageDto>>($"UserMessage/GetMessageSendBox/{id}");
            return response;
        }

        public async Task<bool> UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var response = await _httpClient.PostAsJsonAsync<UpdateMessageDto>("UserMessage", updateMessageDto);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }
    }
}
