using MongoDB.Driver;
using ChatSupport.API.Domain.Entities;
using ChatSupport.API.Infrastructure.Mongo;

namespace ChatSupport.API.Repositories;

public class MessageRepository
{
    private readonly IMongoCollection<Message> _messages;

    public MessageRepository(MongoDbContext context)
    {
        _messages = context.Messages;
    }

    public async Task SaveMessageAsync(Message message)
    {
        await _messages.InsertOneAsync(message);
    }

    public async Task<List<Message>> GetMessagesByChatIdAsync(string chatId)
    {
        return await _messages
            .Find(x => x.ChatId == chatId)
            .SortBy(x => x.SentAt)
            .ToListAsync();
    }
}