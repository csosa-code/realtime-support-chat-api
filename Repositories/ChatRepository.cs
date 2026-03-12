using MongoDB.Driver;
using ChatSupport.API.Domain.Entities;
using ChatSupport.API.Infrastructure.Mongo;

namespace ChatSupport.API.Repositories;

public class ChatRepository
{
    private readonly IMongoCollection<Chat> _chats;

    public ChatRepository(MongoDbContext context)
    {
        _chats = context.Chats;
    }

    public async Task<Chat> CreateChatAsync(Chat chat)
    {
        await _chats.InsertOneAsync(chat);
        return chat;
    }

    public async Task<Chat?> GetChatByIdAsync(string chatId)
    {
        return await _chats
            .Find(x => x.Id == chatId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Chat>> GetActiveChatsAsync()
    {
        return await _chats
            .Find(x => x.Status == "active")
            .SortByDescending(x => x.CreatedAt)
            .ToListAsync();
    }

    public async Task CloseChatAsync(string chatId)
    {
        var update = Builders<Chat>.Update
            .Set(x => x.Status, "closed");

        await _chats.UpdateOneAsync(x => x.Id == chatId, update);
    }

    public async Task<Chat?> GetActiveChatByEmailAsync(string email)
    {
        return await _chats
            .Find(x => x.Email == email && x.Status == "active")
            .FirstOrDefaultAsync();
    }
}