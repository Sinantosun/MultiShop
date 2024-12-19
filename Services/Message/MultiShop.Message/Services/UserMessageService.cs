using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Context;
using MultiShop.Message.DAL.Entites;
using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public class UserMessageService : IUserMessageService
    {
        private readonly MessageContext _messageContext;
        private readonly IMapper _mapper;
        public UserMessageService(MessageContext messageContext, IMapper mapper)
        {
            _messageContext = messageContext;
            _mapper = mapper;
        }

        public async Task CreateMessageAsync(CreateMessageDto createMessageDto)
        {
            var values = _mapper.Map<UserMessage>(createMessageDto);
            await _messageContext.UserMessages.AddAsync(values);
            await _messageContext.SaveChangesAsync();
        }

        public async Task DeleteMessageAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            _messageContext.UserMessages.Remove(value);
            await _messageContext.SaveChangesAsync();
        }

        public async Task<List<ResultInboxMessageDto>> GetInboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(t => t.ReviverId == id).ToListAsync();
            return _mapper.Map<List<ResultInboxMessageDto>>(values);
        }

        public async Task<GetByIdMessageByIdDto> GetMessageByIdAsync(int id)
        {
            var value = await _messageContext.UserMessages.FindAsync(id);
            return _mapper.Map<GetByIdMessageByIdDto>(value);
        }

        public async Task<List<ResultMessageDto>> GetMessageListAsync()
        {
            var values = await _messageContext.UserMessages.ToListAsync();
            return _mapper.Map<List<ResultMessageDto>>(values);
        }

        public async Task<List<ResultSendboxMessageDto>> GetSendboxMessageAsync(string id)
        {
            var values = await _messageContext.UserMessages.Where(t => t.SenderId == id).ToListAsync();
            return _mapper.Map<List<ResultSendboxMessageDto>>(values);
        }

        public async Task UpdateMessageAsync(UpdateMessageDto updateMessageDto)
        {
            var value = _messageContext.UserMessages.Find(updateMessageDto.UserMessageId);
            value.SenderId = updateMessageDto.SenderId;
            value.Subject = updateMessageDto.Subject;
            value.MessageDetail = updateMessageDto.MessageDetail;
            value.ReviverId = updateMessageDto.ReviverId;
            value.MesssageDate = updateMessageDto.MesssageDate;
            value.IsRead = updateMessageDto.IsRead;
            _messageContext.UserMessages.Update(value);
            await _messageContext.SaveChangesAsync();
        }
    }
}
