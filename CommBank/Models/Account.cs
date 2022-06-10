using MongoDB.Bson;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace CommBank.Models;

public class Account
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public long? Number { get; set; }

    public string? Name { get; set; }

    public Int64 Balance { get; set; } = 0;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    [BsonRepresentation(BsonType.String)]
    public AccountType AccountType { get; set; }

    public ObjectId? ApplicationId { get; set; }

    public List<ObjectId>? TransactionIds { get; set; }
}