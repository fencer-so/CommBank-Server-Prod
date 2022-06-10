using MongoDB.Bson;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace CommBank.Models;

public class Transaction
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [BsonRepresentation(BsonType.String)]
    public TransactionType TransactionType { get; set; }

    public Int64 Amount { get; set; } = 0;

    public DateTime DateTime { get; set; } = DateTime.Now;

    [BsonRepresentation(BsonType.ObjectId)]
    public string? GoalId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string? UserId { get; set; }

    [BsonRepresentation(BsonType.ObjectId)]
    public string[]? TagIds { get; set; }

    public string? Description { get; set; }
}