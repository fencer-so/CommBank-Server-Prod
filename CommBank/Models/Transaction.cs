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

    public ObjectId? GoalId { get; set; }

    public string? Description { get; set; }
}