using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ChatSupport.API.Domain.Entities;

public class Message
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = default!;

    public string ChatId { get; set; } = default!;

    public string Sender { get; set; } = default!; // user | agent

    public string Text { get; set; } = default!;

    public DateTime SentAt { get; set; } = DateTime.UtcNow;
}