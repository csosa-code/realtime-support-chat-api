using MongoDB.Driver;
using Microsoft.Extensions.Options;
using ChatSupport.API.Domain.Entities;

namespace ChatSupport.API.Infrastructure.Mongo;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoDbSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);
        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<Chat> Chats =>
        _database.GetCollection<Chat>("Chats");

    public IMongoCollection<Message> Messages =>
        _database.GetCollection<Message>("Messages");
}