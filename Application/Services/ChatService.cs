using ChatSupport.API.Domain.Entities;
using ChatSupport.API.Repositories;

namespace ChatSupport.API.Application.Services;

public class ChatService
{
    private readonly ChatRepository _chatRepository;
    private readonly MessageRepository _messageRepository;

    public ChatService(
        ChatRepository chatRepository,
        MessageRepository messageRepository)
    {
        _chatRepository = chatRepository;
        _messageRepository = messageRepository;
    }

    public async Task<Chat> CreateChatAsync(string userName, string email)
    {
        // Check if the user already has an active chat
        var existingChat = await _chatRepository.GetActiveChatByEmailAsync(email);

        if (existingChat != null)
        {
            return existingChat;
        }

        // If no active chat exists, create a new one
        var chat = new Chat
        {
            UserName = userName,
            Email = email
        };

        return await _chatRepository.CreateChatAsync(chat);
    }

    public async Task SaveMessageAsync(string chatId, string sender, string text)
    {
        var message = new Message
        {
            ChatId = chatId,
            Sender = sender,
            Text = text
        };

        await _messageRepository.SaveMessageAsync(message);
    }

    public async Task<List<Message>> GetChatMessagesAsync(string chatId)
    {
        return await _messageRepository.GetMessagesByChatIdAsync(chatId);
    }

    public async Task<List<Chat>> GetActiveChatsAsync()
    {
        return await _chatRepository.GetActiveChatsAsync();
    }
}